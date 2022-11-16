using LoLRunes.View.ViewModel;
using System.Collections.Generic;

namespace LoLRunes.Application.Services.Interfaces
{
    public interface IRunePageAppService
    {
        void ApplyRunePage(RunePageViewModel runePageViewModel);
        RunePageViewModel EditRunePage(RunePageViewModel runePageViewModel);
        List<RunePageViewModel> ReadAllRunePages();
        RunePageViewModel SaveRunePage(RunePageViewModel runePageViewModel);
    }
}