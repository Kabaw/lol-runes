using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(Toggle))]
public class TogglePlus : MonoBehaviour
{
    private Toggle toogle;

    [SerializeField] UnityEvent onSelect;

    private void Awake()
    {
        toogle = GetComponent<Toggle>();

        toogle.onValueChanged.AddListener(OnValueChange);
    }

    private void OnValueChange(bool value)
    {
        if (!value) return;

        onSelect.Invoke();
    }
}
