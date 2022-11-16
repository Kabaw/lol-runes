﻿using LolRunes.Shared.Exceptions;
using LoLRunes.Application.Services.Interfaces;
using LoLRunes.Infra;
using LoLRunes.Shared.Enums;
using LoLRunes.Shared.Extensions;
using LoLRunes.View.UI;
using LoLRunes.View.ViewModel;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

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
        [SerializeField] private TMP_InputField pageNameInput;
        [SerializeField] private TMP_InputField buildLinkInput;

        private RuneViewModel lastAssignedSidePathRune = null;
        private RunePageViewModel loadedRunePage;
        private List<RunePageViewModel> runePages;        
        private IRunePageAppService runePageAppService;
        private IInspectorDataProvider inspectorDataProvider;

        [Inject]
        public void Constructor(IRunePageAppService runePageAppService, IInspectorDataProvider inspectorDataProvider)
        {
            this.runePageAppService = runePageAppService;
            this.inspectorDataProvider = inspectorDataProvider;
        }

        private void Start()
        {
            runePages = runePageAppService.ReadAllRunePages();

            SetSearchableOption();

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

        public void NewRunePage()
        {
            loadedRunePage = new RunePageViewModel();

            pageNameInput.text = "New Rune Page";

            mainPath.ResetPath();
            sidePath.ResetPath();
            runeShardsComp.ResetShards();
        }

        public void ApplyRunePage()
        {
            runePageAppService.ApplyRunePage(loadedRunePage);
        }

        public void SaveRunePage()
        {
            loadedRunePage.Name = pageNameInput.text.Trim();
            loadedRunePage.BuildLink = buildLinkInput.text.Trim();

            RunePageViewModel runePage;

            try
            {
                if (loadedRunePage.Id == 0)
                    runePage = runePageAppService.SaveRunePage(loadedRunePage);
                else
                    runePage = runePageAppService.EditRunePage(loadedRunePage);
            }
            catch (BusinessLogicException ex)
            {
                if(ex.displayErrorMessage)
                    MessageWindowController.instance.DisplayMessage(ex.title, ex.Message);

                return;
            }                

            loadedRunePage = runePage.DeepCopy();

            runePages.RemoveAll(p => p.Id == runePage.Id);
            runePages.Add(runePage);

            SetSearchableOption(runePage.Name);
        }

        public void SetRuneMenu(int runeMenu)
        {
            inspectorDataProvider.runeMenu = (RuneMenuEnum)runeMenu;
        }

        private void LoadRunePage(RunePageViewModel runePage)
        {
            loadedRunePage = runePage.DeepCopy();

            pageNameInput.text = loadedRunePage.Name;
            buildLinkInput.text = loadedRunePage.BuildLink;

            mainPath.SelectPathRunes(runePage);
            sidePath.SelectPathRunes(runePage);
            runeShardsComp.SelectRuneShards(runePage);
        }

        private void SetSearchableOption(string optionText = null)
        {
            searchableDropdown.options = runePages.Select(r => r.Name).ToList();

            if(optionText != null)
                searchableDropdown.DefineSelectedOption(optionText);
        }

        private void OnRunePageSearched(string selectOptionText)
        {
            LoadRunePage(runePages.Find(p => p.Name == selectOptionText));
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
