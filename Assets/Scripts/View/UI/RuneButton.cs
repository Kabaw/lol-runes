using LoLRunes.Enumerators;
using LoLRunes.LiteralIdentifiers;
using LoLRunes.Utils.UnityComponents;
using LoLRunes.View.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LoLRunes.View.UI
{
    public class RuneButton : MonoBehaviour
    {
        [SerializeField] private RuneTypeEnum runeType;

        private Transform pathRoot;
        private RunePageViewController runePageViewController;

        private void Start()
        {
            pathRoot = TransformUtility.FindParentByTag(transform, TagName.PathRoot);

            runePageViewController = GetComponentInParent<RunePageViewController>();
        }

        public void ButtonClick()
        {
            runePageViewController.SelectRune(runeType, pathRoot);
        }
    }
}