using LoLRunes.Shared.Enums;
using LoLRunes.Shared.LiteralIdentifiers;
using LoLRunes.Shared.Utils.UnityComponents;
using LoLRunes.View.Controllers;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace LoLRunes.View.UI
{
    public class RuneButton : MonoBehaviour
    {
        [SerializeField, FormerlySerializedAs("runeType")] private RuneTypeEnum _runeType;
        
        private Transform pathRoot;
        private RunePageViewController runePageViewController;

        public RuneTypeEnum runeType => _runeType;
        public Button button { get; private set; }

        private void Awake()
        {
            button = GetComponent<Button>();
            pathRoot = TransformUtility.FindParentByTag(transform, TagName.PathRoot);

            runePageViewController = GetComponentInParent<RunePageViewController>();
        }

        public void ButtonClick()
        {
            runePageViewController.SelectRune(runeType, pathRoot);
        }
    }
}