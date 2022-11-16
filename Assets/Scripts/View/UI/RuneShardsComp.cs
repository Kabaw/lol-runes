using LoLRunes.Shared.Enums;
using LoLRunes.View.ViewModel;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace LoLRunes.View.UI
{
    public class RuneShardsComp : MonoBehaviour
    {
        [SerializeField] private List<GameObject> runeShardSets;

        public void ResetShards()
        {
            DeactivateAll(runeShardSets);
            ActivateAll(runeShardSets);
        }

        public void SelectRuneShards(RunePageViewModel runePageViewModel)
        {
            ResetShards();

            SelectRune(runeShardSets, runePageViewModel.RuneShardAttack.RuneType);
            SelectRune(runeShardSets, runePageViewModel.RuneShardFlex.RuneType);
            SelectRune(runeShardSets, runePageViewModel.RuneShardDefence.RuneType);
        }

        private void SelectRune(List<GameObject> runeGroupParent, RuneTypeEnum runeType)
        {
            List<RuneButton> runeButtons = new List<RuneButton>();

            foreach (GameObject go in runeGroupParent)
                runeButtons.AddRange(go.GetComponentsInChildren<RuneButton>().ToList());

            Button runeButton = runeButtons.Find(b => b.runeType == runeType).button;

            if (runeButton)
                runeButton.transform.parent.GetComponent<RuneRadioButton>().DefineSelectedButton(runeButton);
        }

        private void ActivateAll(List<GameObject> gameObjects)
        {
            foreach (GameObject go in gameObjects)
                go.SetActive(true);
        }

        private void DeactivateAll(List<GameObject> gameObjects)
        {
            foreach (GameObject go in gameObjects)
                go.SetActive(false);
        }
    }
}