using LoLRunes.Shared.Enums;
using System;

namespace Assets.Scripts.Shared.Dtos
{
    [Serializable]
    public class LcuRune
    {
        public string id;
        public RuneTypeEnum runeType;

        public LcuRune(string id, RuneTypeEnum runeType)
        {
            this.id = id;
            this.runeType = runeType;
        }
    }
}