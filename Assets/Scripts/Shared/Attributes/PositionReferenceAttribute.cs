using LoLRunes.Shared.Enums;
using System;

namespace LoLRunes.Shared.CustumAttributes
{
    public class RunePositionReferenceAttribute : Attribute
    {
        public RunePositionReferenceEnum RunePositionReference { get; }

        public RunePositionReferenceAttribute(RunePositionReferenceEnum runePositionReference)
        {
            RunePositionReference = runePositionReference;
        }
    }
}