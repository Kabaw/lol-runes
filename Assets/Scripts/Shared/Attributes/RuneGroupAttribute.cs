using LoLRunes.Enumerators;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoLRunes.CustumAttributes
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