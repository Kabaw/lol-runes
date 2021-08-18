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

        private RuneViewModel lastAssignedSidePathRune = null;
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
            }
        }

        private void SelectSidePathRune(RuneViewModel rune)
        {
            if(rune.RuneType.GetGroup() == RuneGroupEnum.PATH)
            {
                runePage.SidePath = rune;
                return;
            }

            if(rune.RuneType.GetGroup() == RuneGroupEnum.RUNE_01 ||
               rune.RuneType.GetGroup() == RuneGroupEnum.RUNE_02 ||
               rune.RuneType.GetGroup() == RuneGroupEnum.RUNE_03)
            {
                if(lastAssignedSidePathRune == null)
                {
                    runePage.SidePathRune_01 = rune;                    
                }
                else
                {
                    if(lastAssignedSidePathRune == runePage.SidePathRune_01)
                        runePage.SidePathRune_02 = rune;
                    else
                        runePage.SidePathRune_01 = rune;
                }

                lastAssignedSidePathRune = rune;
            }
        }

        private void SelectRuneShard(RuneViewModel rune)
        {
            switch (rune.RuneType.GetGroup())
            {
                case RuneGroupEnum.SHARDS_ATTACK:
                    runePage.RuneShardAttack = rune;
                    break;

                case RuneGroupEnum.SHARDS_FLEX:
                    runePage.RuneShardFlex = rune;
                    break;

                case RuneGroupEnum.SHARDS_DEFENCE:
                    runePage.RuneShardDefence = rune;
                    break;
            }
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
