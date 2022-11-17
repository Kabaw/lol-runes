using LoLRunes.Shared.Enums;
using System.Drawing;

namespace LoLRunes.LeagueClienteCommunication.Strategies.WindowInteraction.Services.Interfaces
{
    public interface IRunePagePositionService
    {
        bool GetRunePosition(RunePositionReferenceEnum runePositionReference, PathTypeEnum pathType, out Point point);
        bool GetSidePathRunePosition(RunePositionReferenceEnum sideRunePositionReference, RunePositionReferenceEnum mainRunePositionReference, out Point point);
    }
}