using LoLRunes.Enumerators;
using System.Collections.Generic;
using UnityEngine;

namespace LoLRunes.View.UI
{
    public class PathComp : MonoBehaviour
    {
        [SerializeField] private PathTypeEnum pathType;        
        [SerializeField] private List<GameObject> keyStones;
        [SerializeField] private List<GameObject> runeSets;

        public void ButtonClick(RuneButton runeButton)
        {
            ActivateByTag(keyStones, runeButton.tag);
            ActivateByTag(runeSets, runeButton.tag);
        }

        private void ActivateByTag(List<GameObject> gameObjects, string tag)
        {
            foreach (GameObject go in gameObjects)
            {
                if (go.CompareTag(tag))
                    go.SetActive(true);
                else
                    go.SetActive(false);
            }
        }
    }
}