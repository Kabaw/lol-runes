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
    public delegate void OnSelectDropdown(string selectOption, int selectOptionIndex);

    public class SearchableDropdown : MonoBehaviour
    {
        public static readonly string EMPTY = " ";

        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TMP_Dropdown dropdown;
        
        private bool isInit = false;
        private bool mouseOverDropdown = false;
        private Coroutine dropdownRerenderCoroutine;
        private List<string> _options;
        private List<string> dropdownOptions;

        private OnSelectDropdown _onSelectDropdown;

        public event OnSelectDropdown onSelectDropdown
        {
            add { _onSelectDropdown += value; }            
            remove { _onSelectDropdown -= value; }
        }

        public List<string> options
        {
            get { return _options; }

            set
            {
                _options = value;

                dropdownOptions = new List<string>();
                dropdownOptions.AddRange(options);
                dropdownOptions.Add(EMPTY);

                dropdown.ClearOptions();
                dropdown.AddOptions(dropdownOptions);

                inputField.text = "";
            }
        }

        private void Start()
        {
            //Mocked values
            List<string> texts = new List<string>() { "Page 01", "Page 02", "Page 03" };

            options = texts;
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
            //print("Deselect");
        }

        public void OnEditEnd_Input()
        {
            //print("end edit");
        }

        public void OnChangeValue_Input()
        {
            dropdown.ClearOptions();

            inputField.text = EvaluateCharacters(inputField.text);          

            List<string> names = dropdownOptions.Where(n => n.ToLower().Contains(inputField.text.ToLower())).ToList();
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

            int optionIndex = dropdown.value;
            string optionText = dropdownOptions[dropdown.value];

            inputField.text = optionText;
            dropdown.ClearOptions();
            ResetInputCaretPosition();

            _onSelectDropdown?.Invoke(optionText, optionIndex);
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