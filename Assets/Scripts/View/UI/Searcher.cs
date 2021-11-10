using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using LoLRunes.View.ViewModel;
using System;
using System.Linq;

namespace LoLRunes.View.UI
{
    public class Searcher : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TMP_Dropdown dropdown;

        private bool isInit = false;
        private bool mouseOverDropdown = false;
        private List<RunePageViewModel> _runePages;

        public List<RunePageViewModel> runePages
        {
            get { return _runePages; }

            set
            {
                _runePages = value;

                dropdown.ClearOptions();
                dropdown.AddOptions(_runePages.Select(r => r.Name).ToList());
            }
        }

        private void Start()
        {
            //Mocked values
            List<RunePageViewModel> pages = new List<RunePageViewModel>();

            pages.Add(new RunePageViewModel() { Name = "Page 01" });
            pages.Add(new RunePageViewModel() { Name = "Page 02" });
            pages.Add(new RunePageViewModel() { Name = "Page 03" });

            runePages = pages;
            //Mocked values
        }

        private void Update()
        {
            EvaluateMouseClick();
        }

        private void LateUpdate()
        {
            if (mouseOverDropdown)
            {
                print("SELECTED meeeeeeeeeeeeeeee " + inputField.text.Length);
                inputField.Select();
                inputField.caretPosition = inputField.caretWidth + 100;
            }
        }

        public void OnSelect_Input()
        {
            print("SELECTED");
            dropdown.Show();
        }

        public void OnDeselect_Input()
        {
            dropdown.Hide();
            print(inputField.caretWidth);
        }

        public void OnMouseEnter_Dropdown()
        {
            mouseOverDropdown = true;
            inputField.Select();
            print("in");
        }

        public void OnMouseExit_Dropdown()
        {
            mouseOverDropdown = false;
            print("out");
        }

        public void OnChangeValue_Dropdown()
        {
            inputField.text = runePages[dropdown.value].Name;
        }

        private void OnMouseClick_Dropdown()
        {
            mouseOverDropdown = false;
        }

        private void EvaluateMouseClick()
        {
            if (mouseOverDropdown && Input.GetMouseButtonUp(0))
                OnMouseClick_Dropdown();
        }
    }
}