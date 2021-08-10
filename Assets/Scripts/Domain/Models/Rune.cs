using LoLRunes.Enumerators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoLRunes.Domain.Models
{
    public class Rune
    {
        public RuneTypeEnum RuneType { get; private set; }

        public Rune(RuneTypeEnum runeType)
        {
            RuneType = runeType;

            runeType.get
        }
    }
}