using LoLRunes.CustumData;
using LoLRunes.Enumerators;
using LoLRunes.ScriptableObjects;
using System.Drawing;

namespace LoLRunes.Domain.Interfaces
{
    public interface IRunePagePositionService
    {
        bool GetRunePosition(RunePositionReferenceEnum runePositionReference, PathTypeEnum pathType, out Point point);
        bool GetSidePathRunePosition(RunePositionReferenceEnum sideRunePositionReference, RunePositionReferenceEnum mainRunePositionReference, out Point point);
    }
}