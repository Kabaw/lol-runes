using LoLRunes.Domain.Models;
using LoLRunes.Shared.CustumData;

namespace LoLRunes.LeagueClienteCommunication.Strategies.WindowInteraction.Services.Interfaces
{
    public interface ILeagueWindowInteractionService
    {
        Point2D GetWindowTopLeftPoint();
        void SetFrontWindow();
    }
}