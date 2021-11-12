using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using LoLRunes.View.ViewModel;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LoLRunes.View.UI
{
    public class SearchableDropdown : MonoBehaviour
    {
        public static readonly string EMPTY = " ";

        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TMP_Dropdown dropdown;
        
        private bool isInit = false;
        private bool mouseOverDropdown = false;
        private Coroutine dropdownRerenderCoroutine;
        private List<RunePageViewModel> _runePages;
        private List<string> dropdownTexts;

        public List<RunePageViewModel> runePages
        {
            get { return _runePages; }

            set
            {
                _runePages = value;

                dropdownTexts = new List<string>();
                dropdownTexts.AddRange(_runePages.Select(r => r.Name));
                dropdownTexts.Add(EMPTY);

                dropdown.ClearOptions();
                dropdown.AddOptions(dropdownTexts);

                inputField.text = "";
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
                SelectInput();                
            }
        }

        public void OnSelect_Input()
        {
            ShowDropdown();
        }

        public void OnDeselect_Input()
        {
            print("Deselect");
        }

        public void OnEditEnd_Input()
        {
            print("end edit");
        }

        public void OnChangeValue_Input()
        {
            dropdown.ClearOptions();

            inputField.text = EvaluateCharacters(inputField.text);          

            //List<string> names = _runePages.Where(rp => rp.Name.ToLower().Contains(inputField.text.ToLower())).Select(r => r.Name).ToList();
            List<string> names = dropdownTexts.Where(n => n.ToLower().Contains(inputField.text.ToLower())).ToList();
            names.Add(EMPTY);

            dropdown.AddOptions(names);
            dropdown.value = dropdown.options.Count - 1;

            if(dropdown.IsExpanded)
                dropdown.Hide();

            SelectInput();
            ShowDropdownAfterDelay();
        }

        public void OnMouseEnter_Dropdown()
        {
            mouseOverDropdown = true;
            SelectInput();
        }

        public void OnMouseExit_Dropdown()
        {
            mouseOverDropdown = false;
        }

        public void OnChangeValue_Dropdown()
        {
            if (dropdown.options[dropdown.value].text == EMPTY)
                return;
            
            inputField.text = runePages[dropdown.value].Name;
            dropdown.ClearOptions();
            ResetInputCaretPosition();
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

        private void SelectInput()
        {
            inputField.Select();
            ResetInputCaretPosition();
        }

        private void ShowDropdown()
        {
            if (dropdown.options.Count > 1)
                dropdown.Show();
        }

        private string EvaluateCharacters(string text)
        {
            return text;
            return Regex.Replace(text, @"^\w+$", "").Trim();
        }

        private void ResetInputCaretPosition()
        {
            inputField.caretPosition = inputField.caretWidth + 100;
        }

        private void ShowDropdownAfterDelay()
        {
            if (dropdownRerenderCoroutine != null)
                StopCoroutine(dropdownRerenderCoroutine);

            dropdownRerenderCoroutine = StartCoroutine(DropdownRerenderRoutine());
        }

        private IEnumerator DropdownRerenderRoutine()
        {
            yield return new WaitForSeconds(0.2f);

            ShowDropdown();
            SelectInput();
            dropdownRerenderCoroutine = null;
        }
    }
}