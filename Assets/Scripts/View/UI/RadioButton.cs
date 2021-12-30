using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using LoLRunes.Enumerators;

namespace LoLRunes.View.UI
{
    public delegate void OnRadioSelectionChange(RadioButton radioButton);

    public class RadioButton : MonoBehaviour
    {
        private static OnRadioSelectionChange _onRadioSelectionChange;

        public static event OnRadioSelectionChange onRadioSelectionChange
        {
            add { _onRadioSelectionChange += value; }
            remove { _onRadioSelectionChange -= value; }
        }

        [SerializeField] private Color selectedTint;
        [SerializeField] private Color unselectedTint;
        [SerializeField] private Button[] buttons;

        public Button selectedButton { get; private set; }

        public void DefineSelectedButton(Button button, bool triggerEvents = false)
        {
            ColorBlock colors;

            foreach (Button b in buttons)
            {
                if (b == button)
                {
                    colors = b.colors;
                    colors.normalColor = selectedTint;
                    b.colors = colors;

                    if (selectedButton != b)
                    {
                        if(triggerEvents)
                            _onRadioSelectionChange?.Invoke(this);

                        selectedButton = b;
                    }
                }
                else
                {
                    colors = b.colors;
                    colors.normalColor = unselectedTint;
                    b.colors = colors;
                }
            }
        }

        public void ButtonClick(Button button)
        {
            DefineSelectedButton(button, true);
        }

        public void ResetRadio(ButtonTintEnum startTint = ButtonTintEnum.SELECTED_TINT)
        {
            ColorBlock colors;

            selectedButton = null;

            foreach (Button b in buttons)
            {
                b.interactable = true;

                colors = b.colors;
                colors.normalColor = startTint == ButtonTintEnum.SELECTED_TINT ? selectedTint : unselectedTint;
                b.colors = colors;
            }
        }

        private void OnEnable()
        {
            ResetRadio();
        }
    }
}