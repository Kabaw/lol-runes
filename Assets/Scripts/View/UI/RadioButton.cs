using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RadioButton : MonoBehaviour
{
    [SerializeField] private Color selectedTint;
    [SerializeField] private Color unselectedTint;
    [SerializeField] private Button[] buttons;

    public Button selectedButton { get; private set; }

    public void ButtonClick(Button button)
    {
        ColorBlock colors;

        foreach (Button b in buttons)
        {
            if (b == button)
            {
                colors = b.colors;
                colors.normalColor = selectedTint;
                b.colors = colors;

                selectedButton = b;
            }                
            else
            {
                colors = b.colors;
                colors.normalColor = unselectedTint;
                b.colors = colors;
            }
        }
    }
    
    private void DefineSelectedButton(Button button)
    {
        ButtonClick(button);
    }

    private void ResetRadio()
    {
        ColorBlock colors;

        selectedButton = null;

        foreach (Button b in buttons)
        {
            b.interactable = true;

            colors = b.colors;
            colors.normalColor = selectedTint;
            b.colors = colors;
        }
    }

    private void OnEnable()
    {
        ResetRadio();
    }
}