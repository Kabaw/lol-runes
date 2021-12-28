using LoLRunes.Enumerators;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using LoLRunes.LiteralIdentifiers;
using System.Linq;
using LoLRunes.View.ViewModel;

namespace LoLRunes.View.UI
{
    public delegate void OnPathChanged(PathComp pathComp);

    public class PathComp : MonoBehaviour
    {
        private static OnPathChanged _onPathChanged;

        public static event OnPathChanged onPathChanged
        {
            add { _onPathChanged += value; }
            remove { _onPathChanged -= value; }
        }

        [SerializeField, FormerlySerializedAs("pathType")] private PathTypeEnum _pathType;
        [SerializeField] private RadioButton _pathRunesRadio;
        [SerializeField] private List<RuneButton> pathButtons;
        [SerializeField] private List<GameObject> keyStones;
        [SerializeField] private List<GameObject> runeSets;

        public PathTypeEnum pathType => _pathType;
        public RadioButton pathRunesRadio => _pathRunesRadio;

        private void Awake()
        {
            if (pathType == PathTypeEnum.SIDE)
                onPathChanged += OnPathChanged;
        }

        public void ButtonClick(RuneButton runeButton)
        {
            ActivateByTag(keyStones, runeButton.tag);
            ActivateByTag(runeSets, runeButton.tag);

            _onPathChanged?.Invoke(this);
        }

        public void SelectPathRunes(RunePageViewModel runePageViewModel)
        {
            //ResetPath();

            if (pathType == PathTypeEnum.MAIN)
            {
                SelectRune(pathButtons.Select(b => b.gameObject).ToList(), runePageViewModel.MainPath.RuneType);

                SelectRune(keyStones, runePageViewModel.KeyStone.RuneType);

                SelectRune(runeSets, runePageViewModel.MainPathRune_01.RuneType);
                SelectRune(runeSets, runePageViewModel.MainPathRune_02.RuneType);
                SelectRune(runeSets, runePageViewModel.MainPathRune_03.RuneType);
            }
            else
            {
                SelectRune(pathButtons.Select(b => b.gameObject).ToList(), runePageViewModel.SidePath.RuneType);

                SelectRune(runeSets, runePageViewModel.SidePathRune_01.RuneType);
                SelectRune(runeSets, runePageViewModel.SidePathRune_02.RuneType);
            }
        }
        
        public void ResetPath()
        {
            DeactivateAll(keyStones);
            DeactivateAll(runeSets);

            ActivateByTag(keyStones, TagName.Precision);
            ActivateByTag(runeSets, TagName.Precision);

            pathRunesRadio.ResetRadio(ButtonTintEnum.UNSELECTED_TINT);

            if (pathType == PathTypeEnum.MAIN)
                pathButtons.Where(b => b.runeType == RuneTypeEnum.PRECISION_PATH).First().button.onClick.Invoke();
            else
                pathButtons.Where(b => b.runeType == RuneTypeEnum.DOMINATION_PATH).First().button.onClick.Invoke();
        }

        private void SelectRune(List<GameObject> runeGroupParent, RuneTypeEnum runeType)
        {
            List<RuneButton> runeButtons = new List<RuneButton>();

            foreach (GameObject go in runeGroupParent)
                runeButtons.AddRange(go.GetComponentsInChildren<RuneButton>().ToList());

            Button runeButton = runeButtons.Find(b => b.runeType == runeType).button;

            if(runeButton)
                runeButton.transform.parent.GetComponent<RadioButton>().DefineSelectedButton(runeButton);
        }

        private void ActivateByTag(List<GameObject> gameObjects, string tag)
        {
            foreach (GameObject go in gameObjects)
            {
                if (go.CompareTag(tag))
                    go.SetActive(true);
                else
                    go.SetActive(false);
            }
        }

        private void DeactivateAll(List<GameObject> gameObjects)
        {
            foreach (GameObject go in gameObjects)
                go.SetActive(false);
        }

        private void OnPathChanged(PathComp pathComp)
        {
            ValidateCurrentPathChange(pathComp);
            DisableSelectedMainPath(pathComp, pathComp.pathRunesRadio.selectedButton);
        }

        private void ValidateCurrentPathChange(PathComp pathComp)
        {
            if (pathComp.pathType == PathTypeEnum.SIDE) return;

            if (!pathRunesRadio.selectedButton) return;

            if (pathComp.pathRunesRadio.selectedButton.CompareTag(pathRunesRadio.selectedButton.tag))
            {
                foreach (RuneButton runeButton in pathButtons)
                {
                    if (!runeButton.CompareTag(pathComp.pathRunesRadio.selectedButton.tag))
                    {
                        runeButton.button.onClick.Invoke();
                        return;
                    }
                }
            }
        }

        private void DisableSelectedMainPath(PathComp pathComp, Button button)
        {
            if (pathComp.pathType == PathTypeEnum.SIDE) return;

            foreach (RuneButton runeButton in pathButtons)
            {
                if(runeButton.CompareTag(button.tag))
                    runeButton.button.interactable = false;
                else
                    runeButton.button.interactable = true;
            }
        }

        private void OnDestroy()
        {
            if (pathType == PathTypeEnum.SIDE)
                onPathChanged -= OnPathChanged;
        }
    }
}