using LoLRunes.Enumerators;
using LoLRunes.Enumerators.Extensions;
using LoLRunes.View.UI;
using LoLRunes.View.ViewModel;
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
        [SerializeField] private RuneShardsComp runeShardsComp; 

        [Header("Path Runes Roots")]
        [SerializeField] private Transform mainPathRunesRoot;
        [SerializeField] private Transform sidePathRunesRoot;

        private RunePageViewModel runePage;

        // Start is called before the first frame update
        void Start()
        {

        }

        public void SelectRune(RuneTypeEnum runeType, Transform runePathRoot)
        {
            RuneViewModel rune = new RuneViewModel() { RuneType = runeType };

            if (runePathRoot == mainPathRunesRoot)
                SelectMainPathRune(rune);
            else if (runePathRoot == sidePathRunesRoot)
                SelectSidePathRune(rune);
            else
                SelectRuneShard(rune);
        }

        private void SelectMainPathRune(RuneViewModel rune)
        {
            switch (rune.RuneType.GetGroup())
            {
                case RuneGroupEnum.PATH:
                    runePage.MainPath = rune;
                    break;

                case RuneGroupEnum.KEYSTONE:
                    runePage.KeyStone = rune;
                    break;

                case RuneGroupEnum.RUNE_01:
                    runePage.MainPathRune_01 = rune;
                    break;

                case RuneGroupEnum.RUNE_02:
                    runePage.MainPathRune_02 = rune;
                    break;

                case RuneGroupEnum.RUNE_03:
                    runePage.MainPathRune_03 = rune;
                    break;

                default:
                    runePage.MainPath = rune;
                    break;
            }
        }

        private void SelectSidePathRune(RuneViewModel rune)
        {

        }

        private void SelectRuneShard(RuneViewModel rune)
        {

        }

        private void NewRunePage()
        {
            runePage = new RunePageViewModel();

            mainPath.ResetPath();
            sidePath.ResetPath();
            runeShardsComp.ResetShards();
            //create new rune page ViewModel
        }
    }
}
