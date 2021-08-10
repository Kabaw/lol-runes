using LoLRunes.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoLRunes.CustumAttributes
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