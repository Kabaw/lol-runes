using LoLRunes.View.ViewModel;
using LoLRunes.Domain.Commands;
using LoLRunes.Domain.Services;
using LoLRunes.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LoLRunes.Application.Services
{   
    public class RunePageAppService
    {
        private IRuneService runeService;
        private RunePageService runePageService;
        private LeagueWindowInteractionService windowInteraction;

        public RunePageAppService(IRuneService runeService, RunePageService runePageService, LeagueWindowInteractionService leagueWindowInteractionService)
        {           
            this.runeService = runeService;
            this.runePageService = runePageService;
            this.windowInteraction = leagueWindowInteractionService;
        }

        public void ApplyRunePage(RunePageViewModel runePageViewModel)
        {
            EvaluateRunePageRequest(runePageViewModel);

            CreateRunePageCommand command = MapToCreateRunePageCommand(runePageViewModel);

            RunePage runePage = runePageService.Instantiate(command);

            windowInteraction.ApplyRunePage(runePage);
        }

        public RunePageViewModel SaveRunePage(RunePageViewModel runePageViewModel)
        {
            EvaluateRunePageRequest(runePageViewModel);

            CreateRunePageCommand command = MapToCreateRunePageCommand(runePageViewModel);

            RunePage runePage = runePageService.Instantiate(command);

            runePage = runePageService.Save(runePage);

            return MapToRunePageViewModel(runePage);
        }

        public List<RunePageViewModel> ReadAllRunePages()
        {
            List<RunePage> runePages = runePageService.ReadAll();

            return MapToRunePageViewModelList(runePages);
        }

        public RunePageViewModel EditRunePage(RunePageViewModel runePageViewModel)
        {
            EvaluateRunePageRequest(runePageViewModel);

            RunePage runePage = runePageService.Read(runePageViewModel.Id);

            EditRunePageCommand command = MapToEditRunePageCommand(runePageViewModel);

            runePage = runePageService.Edit(runePage, command);

            return MapToRunePageViewModel(runePage);
        }

        private void EvaluateRunePageRequest(RunePageViewModel runePageViewModel)
        {
            if (runePageViewModel.Name == null ||
                runePageViewModel.BuildLink == null ||
                runePageViewModel.MainPath == null ||
                runePageViewModel.SidePath == null ||
                runePageViewModel.KeyStone == null ||
                runePageViewModel.MainPathRune_01 == null ||
                runePageViewModel.MainPathRune_02 == null ||
                runePageViewModel.MainPathRune_03 == null ||
                runePageViewModel.SidePathRune_01 == null ||
                runePageViewModel.SidePathRune_02 == null ||
                runePageViewModel.RuneShardAttack == null ||
                runePageViewModel.RuneShardFlex == null ||
                runePageViewModel.RuneShardDefence == null)
            {
                throw new InvalidOperationException("Some fields have null values");
            }
        }

        #region Mapping
        private CreateRunePageCommand MapToCreateRunePageCommand(RunePageViewModel runePageViewModel)
        {
            CreateRunePageCommand command = new CreateRunePageCommand();

            command.Name = runePageViewModel.Name;
            command.BuildLink = runePageViewModel.BuildLink;
            command.MainPath = runeService.Instantiate(runePageViewModel.MainPath.RuneType);
            command.KeyStone = runeService.Instantiate(runePageViewModel.KeyStone.RuneType);
            command.MainPathRune_01 = runeService.Instantiate(runePageViewModel.MainPathRune_01.RuneType);
            command.MainPathRune_02 = runeService.Instantiate(runePageViewModel.MainPathRune_02.RuneType);
            command.MainPathRune_03 = runeService.Instantiate(runePageViewModel.MainPathRune_03.RuneType);
            command.SidePath = runeService.Instantiate(runePageViewModel.SidePath.RuneType);
            command.SidePathRune_01 = runeService.Instantiate(runePageViewModel.SidePathRune_01.RuneType);
            command.SidePathRune_02 = runeService.Instantiate(runePageViewModel.SidePathRune_02.RuneType);
            command.RuneShardAttack = runeService.Instantiate(runePageViewModel.RuneShardAttack.RuneType);
            command.RuneShardFlex = runeService.Instantiate(runePageViewModel.RuneShardFlex.RuneType);
            command.RuneShardDefence = runeService.Instantiate(runePageViewModel.RuneShardDefence.RuneType);

            return command;
        }

        private EditRunePageCommand MapToEditRunePageCommand(RunePageViewModel runePageViewModel)
        {
            EditRunePageCommand command = new EditRunePageCommand();

            command.Id = runePageViewModel.Id;
            command.Name = runePageViewModel.Name;
            command.BuildLink = runePageViewModel.BuildLink;
            command.MainPath = runeService.Instantiate(runePageViewModel.MainPath.RuneType);
            command.KeyStone = runeService.Instantiate(runePageViewModel.KeyStone.RuneType);
            command.MainPathRune_01 = runeService.Instantiate(runePageViewModel.MainPathRune_01.RuneType);
            command.MainPathRune_02 = runeService.Instantiate(runePageViewModel.MainPathRune_02.RuneType);
            command.MainPathRune_03 = runeService.Instantiate(runePageViewModel.MainPathRune_03.RuneType);
            command.SidePath = runeService.Instantiate(runePageViewModel.SidePath.RuneType);
            command.SidePathRune_01 = runeService.Instantiate(runePageViewModel.SidePathRune_01.RuneType);
            command.SidePathRune_02 = runeService.Instantiate(runePageViewModel.SidePathRune_02.RuneType);
            command.RuneShardAttack = runeService.Instantiate(runePageViewModel.RuneShardAttack.RuneType);
            command.RuneShardFlex = runeService.Instantiate(runePageViewModel.RuneShardFlex.RuneType);
            command.RuneShardDefence = runeService.Instantiate(runePageViewModel.RuneShardDefence.RuneType);

            return command;
        }

        private RunePageViewModel MapToRunePageViewModel(RunePage runePage)
        {
            RunePageViewModel runePageViewModel = new RunePageViewModel();

            runePageViewModel.Id = runePage.Id;
            runePageViewModel.Name = runePage.Name;
            runePageViewModel.BuildLink = runePage.BuildLink;
            runePageViewModel.MainPath = MapToRuneViewModel(runePage.MainPath);
            runePageViewModel.KeyStone = MapToRuneViewModel(runePage.KeyStone);
            runePageViewModel.MainPathRune_01 = MapToRuneViewModel(runePage.MainPathRune_01);
            runePageViewModel.MainPathRune_02 = MapToRuneViewModel(runePage.MainPathRune_02);
            runePageViewModel.MainPathRune_03 = MapToRuneViewModel(runePage.MainPathRune_03);
            runePageViewModel.SidePath = MapToRuneViewModel(runePage.SidePath);
            runePageViewModel.SidePathRune_01 = MapToRuneViewModel(runePage.SidePathRune_01);
            runePageViewModel.SidePathRune_02 = MapToRuneViewModel(runePage.SidePathRune_02);
            runePageViewModel.RuneShardAttack = MapToRuneViewModel(runePage.RuneShardAttack);
            runePageViewModel.RuneShardFlex = MapToRuneViewModel(runePage.RuneShardFlex);
            runePageViewModel.RuneShardDefence = MapToRuneViewModel(runePage.RuneShardDefence);

            return runePageViewModel;
        }

        private List<RunePageViewModel> MapToRunePageViewModelList(List<RunePage> runePages)
        {
            return runePages.Select(r => MapToRunePageViewModel(r)).ToList();
        }

        private RuneViewModel MapToRuneViewModel(Rune rune)
        {
            RuneViewModel runeViewModel = new RuneViewModel();

            runeViewModel.RuneType = rune.RuneType;

            return runeViewModel;
        }
        #endregion
    }
}
