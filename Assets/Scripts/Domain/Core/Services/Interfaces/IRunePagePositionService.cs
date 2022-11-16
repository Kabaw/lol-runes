using LoLRunes.Enumerators;
using System.Drawing;

namespace LoLRunes.Domain.Services.Interfaces
{
    public interface IRunePagePositionService
    {
        bool GetRunePosition(RunePositionReferenceEnum runePositionReference, PathTypeEnum pathType, out Point point);
        bool GetSidePathRunePosition(RunePositionReferenceEnum sideRunePositionReference, RunePositionReferenceEnum mainRunePositionReference, out Point point);
    }
}