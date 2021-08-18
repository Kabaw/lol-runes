using LoLRunes.Enumerators;
using LoLRunes.View.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoLRunes.View.Controllers
{
    public class RunePageViewController : MonoBehaviour
    {
        [Header("Path Components")]
        [SerializeField] private PathComp mainPath;
        [SerializeField] private PathComp sidePath;

        [Header("Path Runes Roots")]
        [SerializeField] private Transform mainPathRunesRoot;
        [SerializeField] private Transform sidePathRunesRoot;

        // Start is called before the first frame update
        void Start()
        {

        }

        public void SelectRune(RuneTypeEnum runeType, Transform runePathRoot)
        {

        }

        private void NewRunePage()
        {
            mainPath.ResetPath();
            sidePath.ResetPath();
            //create new rune page ViewModel
        }
    }
}
