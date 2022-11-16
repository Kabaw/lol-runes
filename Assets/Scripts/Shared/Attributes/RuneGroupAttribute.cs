using LoLRunes.Shared.Enums;
using System;

namespace LoLRunes.Shared.CustumAttributes
{
    public class RuneGroupAttribute : Attribute
    {
        public RuneGroupEnum RuneGroup { get; }

        public RuneGroupAttribute(RuneGroupEnum runeGroup)
        {
            RuneGroup = runeGroup;
        }
    }
}