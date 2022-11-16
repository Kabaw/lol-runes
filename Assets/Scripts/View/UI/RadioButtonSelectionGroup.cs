using LoLRunes.Shared.Enums;
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

        [SerializeField] private List<RuneRadioButton> radioButtons;

        private List<RuneRadioButton> selectedRadios;

        private void Awake()
        {
            selectedRadios = new List<RuneRadioButton>();

            RuneRadioButton.onRadioSelectionChange += OnRadioSelectionChange;
        }

        public void OnRadioSelectionChange(RuneRadioButton radioButton)
        {
            EvaluateRadioGroup(radioButton);
        }

        public void EvaluateRadioGroup(RuneRadioButton radioButton)
        {
            if (!radioButtons.Contains(radioButton)) return;

            if (selectedRadios.Contains(radioButton))
            {
                selectedRadios.Remove(radioButton);
                selectedRadios.Add(radioButton);
                return;
            }

            selectedRadios.Add(radioButton);

            if (selectedRadios.Count == maxSelectionQtd)
            {
                foreach (RuneRadioButton radio in radioButtons)
                {
                    if (!selectedRadios.Contains(radio))
                        radio.ResetRadio(ButtonTintEnum.UNSELECTED_TINT);
                }
            }

            if (selectedRadios.Count > maxSelectionQtd)
            {
                RuneRadioButton removedRadioButton = selectedRadios[0];

                selectedRadios.RemoveAt(0);

                removedRadioButton.ResetRadio(ButtonTintEnum.UNSELECTED_TINT);
            }
        }

        public void ReevaluateRadioGroupState()
        {
            ResetRadioGroup();

            foreach (RuneRadioButton radio in radioButtons)
                if (radio.selectedButton)
                    EvaluateRadioGroup(radio);
        }

        public void ResetRadioGroup()
        {
            selectedRadios = new List<RuneRadioButton>();
        }
    }
}