using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

namespace LoLRunes.View.UI
{
    public class Searcher : MonoBehaviour
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TMP_Dropdown dropdown;

        private bool mouseOverDropdown = false;

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