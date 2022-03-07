using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace LoLRunes.View.UI
{
    public class BuildLinkEdit : MonoBehaviour
    {
        [SerializeField] TMP_InputField buildLinkInput;
        
        public void EditLink()
        {
            buildLinkInput.interactable = true;
        }
    }
}