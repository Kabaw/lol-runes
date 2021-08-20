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

        private void Start()
        {
            NewRunePage();
        }

        public void SelectRune(RuneTypeEnum runeType, Transform runePathRoot)
        {
            RuneViewModel rune = new RuneViewModel() { RuneType = runeType };

            if (EvaluatePath(runePathRoot) == PathTypeEnum.MAIN)
            {
                SelectMainPathRune(rune);
            }
            else if (EvaluatePath(runePathRoot) == PathTypeEnum.SIDE)
            {
                SelectSidePathRune(rune);
            }
            if (runePathRoot == null)
            {
                SelectRuneShard(rune);
            }
        }

        public void NewRunePage()
        {
            runePage = new RunePageViewModel();

            mainPath.ResetPath();
            sidePath.ResetPath();
            runeShardsComp.ResetShards();            
        }

        private void SelectMainPathRune(RuneViewModel rune)
        {
            switch (rune.RuneType.GetGroup())
            {
                case RuneGroupEnum.PATH:
                    if (runePage.MainPath != null &&runePage.MainPath.RuneType != rune.RuneType)
                        ClearRunePageModelPath(PathTypeEnum.MAIN);

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

        private void ClearRunePageModelPath(PathTypeEnum pathType)
        {
            if(pathType == PathTypeEnum.MAIN)
            {
                runePage.MainPath = null;
                runePage.KeyStone = null;
                runePage.MainPathRune_01 = null;
                runePage.MainPathRune_02 = null;
                runePage.MainPathRune_03 = null;
            }
            else
            {
                runePage.SidePath = null;
                runePage.SidePathRune_01 = null;
                runePage.SidePathRune_02 = null;
            }
        }

        private void SelectSidePathRune(RuneViewModel rune)
        {
            if(rune.RuneType.GetGroup() == RuneGroupEnum.PATH)
            {
                if (runePage.SidePath != null && runePage.SidePath.RuneType != rune.RuneType)
                    ClearRunePageModelPath(PathTypeEnum.SIDE);

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

        private PathTypeEnum EvaluatePath(Transform runePathRoot)
        {
            if (runePathRoot == mainPathRunesRoot ||
                runePathRoot == mainPath.transform)
            {
                return PathTypeEnum.MAIN;
            }
            else
            {
                return PathTypeEnum.SIDE;
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
    }
}
