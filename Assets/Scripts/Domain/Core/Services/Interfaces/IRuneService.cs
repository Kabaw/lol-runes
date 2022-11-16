using LoLRunes.Domain.Models;
using LoLRunes.Shared.Enums;

namespace LoLRunes.Domain.Services.Interfaces
{
    public interface IRuneService
    {
        Rune Instantiate(RuneTypeEnum runeType);
    }
}