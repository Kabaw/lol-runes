using LoLRunes.Enumerators;
using LoLRunes.LiteralIdentifiers;
using LoLRunes.Utils.UnityComponents;
using LoLRunes.View.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace LoLRunes.View.UI
{
    public class RuneButton : MonoBehaviour
    {
        [SerializeField] private RuneTypeEnum runeType;
        
        private Transform pathRoot;
        private RunePageViewController runePageViewController;

        public Button button { get; private set; }

        private void Start()
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