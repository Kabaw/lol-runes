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

    private void OnEnable()
    {
        ColorBlock colors;

        foreach (Button b in buttons)
        {
            colors = b.colors;
            colors.normalColor = selectedTint;
            b.colors = colors;
        }
    }
}