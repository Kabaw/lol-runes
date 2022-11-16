using LoLRunes.CustumData;
using LoLRunes.Domain.Models;
using System.Collections;

namespace LoLRunes.Domain.Interfaces
{
    public interface ILeagueWindowInteractionService
    {
        void ApplyRunePage(RunePage runePage);
        Point2D GetWindowTopLeftPoint();
        void SetFrontWindow();
    }
}