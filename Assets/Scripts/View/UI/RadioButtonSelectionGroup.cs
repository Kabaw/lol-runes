using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LoLRunes.View.UI
{
    public class RadioButtonSelectionGroup : MonoBehaviour
    {
        [Tooltip("The maximum number of radio buttons that can be selected at the same time.")]
        [SerializeField] private int maxSelectionQtd;

        [SerializeField] private List<RadioButton> radioButtons;

        private List<RadioButton> selectedRadios;

        private void Awake()
        {
            selectedRadios = new List<RadioButton>();

            RadioButton.onRadioSelectionChange += OnRadioSelectionChange;
        }

        public void OnRadioSelectionChange(RadioButton radioButton)
        {
            if (!radioButtons.Contains(radioButton)) return;

            if (selectedRadios.Contains(radioButton))
            {
                selectedRadios.Remove(radioButton);
                selectedRadios.Add(radioButton);
                return;
            }

            selectedRadios.Add(radioButton);

            if(selectedRadios.Count == maxSelectionQtd)
            {
                foreach (RadioButton radio in radioButtons)
                {
                    if(!selectedRadios.Contains(radio))
                        radio.ResetRadio(Enumerators.ButtonTintEnum.UNSELECTED_TINT);
                }
            }

            if (selectedRadios.Count > maxSelectionQtd)
            {
                RadioButton removedRadioButton = selectedRadios[0];

                selectedRadios.RemoveAt(0);

                removedRadioButton.ResetRadio(Enumerators.ButtonTintEnum.UNSELECTED_TINT);
            }
        }

        public void ResetRadioGroup()
        {
            selectedRadios = new List<RadioButton>();
        }
    }
}