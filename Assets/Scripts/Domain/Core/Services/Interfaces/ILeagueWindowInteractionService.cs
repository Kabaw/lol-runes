using LoLRunes.CustumData;
using LoLRunes.Domain.Models;

namespace LoLRunes.Domain.Services.Interfaces
{
    public interface ILeagueWindowInteractionService
    {
        void ApplyRunePage(RunePage runePage);
        Point2D GetWindowTopLeftPoint();
        void SetFrontWindow();
    }
}