using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace LoLRunes.View.Behaviours
{
    public class BuildLinkComp : MonoBehaviour
    {
        [SerializeField] TMP_InputField buildLinkInput;
        
        public void EditLink()
        {
            string urlName = buildLinkInput.text.Trim();

            Uri uriResult;

            bool validUrl = Uri.TryCreate(urlName, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if (!validUrl)
            {
                //Display error message
                return;
            }

            UnityEngine.Application.OpenURL(urlName);
        }
    }
}