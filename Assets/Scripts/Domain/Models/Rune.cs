using LoLRunes.Shared.Enums;

namespace LoLRunes.Domain.Models
{
    public class Rune
    {
        public RuneTypeEnum RuneType { get; internal set; }

        public Rune(RuneTypeEnum runeType)
        {
            RuneType = runeType;
        }
    }
}