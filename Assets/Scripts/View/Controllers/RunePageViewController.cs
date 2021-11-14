using LoLRunes.Application.Services;
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

        [Header("Misc References")]
        [SerializeField] private SearchableDropdown searchableDropdown;

        private RuneViewModel lastAssignedSidePathRune = null;
        private RunePageViewModel loadedRunePage;
        private List<RunePageViewModel> runePages;

        private RunePageAppService runePageAppService;

        private void Start()
        {
            runePageAppService = new RunePageAppService();

            NewRunePage();

            searchableDropdown.onSelectDropdown += OnRunePageSearched;
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

        public void ApplyRunePage()
        {
            runePageAppService.ApplyRunePage(loadedRunePage);
        }

        public void NewRunePage()
        {
            loadedRunePage = new RunePageViewModel();

            mainPath.ResetPath();
            sidePath.ResetPath();
            runeShardsComp.ResetShards();            
        }

        private void LoadRunePage(RunePageViewModel runePage)
        {

        }

        private void OnRunePageSearched(string selectOption, int selectOptionIndex)
        {

        }

        private void SelectMainPathRune(RuneViewModel rune)
        {
            switch (rune.RuneType.GetGroup())
            {
                case RuneGroupEnum.PATH:
                    if (loadedRunePage.MainPath != null &&loadedRunePage.MainPath.RuneType != rune.RuneType)
                        ClearRunePageModelPath(PathTypeEnum.MAIN);

                    loadedRunePage.MainPath = rune;                    
                    break;

                case RuneGroupEnum.KEYSTONE:
                    loadedRunePage.KeyStone = rune;
                    break;

                case RuneGroupEnum.RUNE_01:
                    loadedRunePage.MainPathRune_01 = rune;
                    break;

                case RuneGroupEnum.RUNE_02:
                    loadedRunePage.MainPathRune_02 = rune;
                    break;

                case RuneGroupEnum.RUNE_03:
                    loadedRunePage.MainPathRune_03 = rune;
                    break;
            }
        }

        private void ClearRunePageModelPath(PathTypeEnum pathType)
        {
            if(pathType == PathTypeEnum.MAIN)
            {
                loadedRunePage.MainPath = null;
                loadedRunePage.KeyStone = null;
                loadedRunePage.MainPathRune_01 = null;
                loadedRunePage.MainPathRune_02 = null;
                loadedRunePage.MainPathRune_03 = null;
            }
            else
            {
                loadedRunePage.SidePath = null;
                loadedRunePage.SidePathRune_01 = null;
                loadedRunePage.SidePathRune_02 = null;
            }
        }

        private void SelectSidePathRune(RuneViewModel rune)
        {
            if(rune.RuneType.GetGroup() == RuneGroupEnum.PATH)
            {
                if (loadedRunePage.SidePath != null && loadedRunePage.SidePath.RuneType != rune.RuneType)
                    ClearRunePageModelPath(PathTypeEnum.SIDE);

                loadedRunePage.SidePath = rune;
                return;
            }

            if(rune.RuneType.GetGroup() == RuneGroupEnum.RUNE_01 ||
               rune.RuneType.GetGroup() == RuneGroupEnum.RUNE_02 ||
               rune.RuneType.GetGroup() == RuneGroupEnum.RUNE_03)
            {
                if(lastAssignedSidePathRune == null)
                {
                    loadedRunePage.SidePathRune_01 = rune;                    
                }
                else
                {
                    if (loadedRunePage.SidePathRune_01 != null &&
                        loadedRunePage.SidePathRune_01.RuneType.GetGroup() == rune.RuneType.GetGroup())
                    {
                        loadedRunePage.SidePathRune_01 = rune;
                        lastAssignedSidePathRune = rune;
                        return;
                    }

                    if (loadedRunePage.SidePathRune_02 != null &&
                        loadedRunePage.SidePathRune_02.RuneType.GetGroup() == rune.RuneType.GetGroup())
                    {                          
                        loadedRunePage.SidePathRune_02 = rune;
                        lastAssignedSidePathRune = rune;
                        return;
                    }

                    if (lastAssignedSidePathRune == loadedRunePage.SidePathRune_01)
                        loadedRunePage.SidePathRune_02 = rune;
                    else
                        loadedRunePage.SidePathRune_01 = rune;
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
                    loadedRunePage.RuneShardAttack = rune;
                    break;

                case RuneGroupEnum.SHARDS_FLEX:
                    loadedRunePage.RuneShardFlex = rune;
                    break;

                case RuneGroupEnum.SHARDS_DEFENCE:
                    loadedRunePage.RuneShardDefence = rune;
                    break;
            }
        }
    }
}
