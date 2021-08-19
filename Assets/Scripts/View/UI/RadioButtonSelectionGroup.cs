using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoLRunes.View.UI
{
    public class RadioButtonSelectionGroup : MonoBehaviour
    {
        [Tooltip("The maximum number of radio buttons that can be selected at the same time.")]
        [SerializeField] private int maxSelectionQtd;

        [SerializeField] private List<RadioButton> radioButtons;

        private Queue<RadioButton> selectedRadios;

        private void Awake()
        {
            selectedRadios = new Queue<RadioButton>();

            RadioButton.onRadioSelectionChange += OnRadioSelectionChange;
        }

        public void OnRadioSelectionChange(RadioButton radioButton)
        {
            if (!radioButtons.Contains(radioButton)) return;

            if (selectedRadios.Contains(radioButton)) return;

            selectedRadios.Enqueue(radioButton);

            if (selectedRadios.Count > maxSelectionQtd)
            {
                RadioButton removedRadioButton = selectedRadios.Dequeue();
                removedRadioButton.ResetRadio(Enumerators.ButtonTintEnum.UNSELECTED_TINT);
            }
        }
    }
}