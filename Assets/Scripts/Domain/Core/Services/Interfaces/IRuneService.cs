using LoLRunes.Domain.Models;
using LoLRunes.Enumerators;

namespace LoLRunes.Domain.Interfaces
{
    public interface IRuneService
    {
        Rune Instantiate(RuneTypeEnum runeType);
    }
}