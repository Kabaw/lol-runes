using LoLRunes.View.ViewModel;
using LoLRunes.Domain.Commands;
using LoLRunes.Domain.Services;
using LoLRunes.Domain.Models;

namespace LoLRunes.Application.Services
{   
    public class RunePageAppService
    {
        private RuneService runeService;
        private RunePageService runePageService;
        private WindowInteractionService windowInteraction;

        public RunePageAppService()
        {           
            runeService = new RuneService();
            runePageService = new RunePageService();
            windowInteraction = new WindowInteractionService();
        }

        public void ApplyRunePage(RunePageViewModel runePageViewModel)
        {
            CreateRunePageCommand command = InstanciaCreateRunePageCommand(runePageViewModel);

            RunePage runePage = runePageService.Instantiate(command);

            windowInteraction.ApplyRunePage(runePage);
        }

        private CreateRunePageCommand InstanciaCreateRunePageCommand(RunePageViewModel runePageViewModel)
        {
            CreateRunePageCommand command = new CreateRunePageCommand();

            command.MainPath = runeService.Instantiate(runePageViewModel.MainPath.RuneType);
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
    }
}
