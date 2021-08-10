using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoLRunes.CustumAttributes
{
    public class PositionReferenceAttribute : Attribute
    {
        public int PositionReference { get; }

        public PositionReferenceAttribute(int positionReference)
        {
            PositionReference = positionReference;
        }
    }
}