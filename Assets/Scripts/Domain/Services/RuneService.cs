using LoLRunes.Domain.Models;
using LoLRunes.Domain.Services.Interfaces;
using LoLRunes.Shared.Enums;

namespace LoLRunes.Domain.Services
{
    public class RuneService : IRuneService
    {
        public RuneService() { }

        public Rune Instantiate(RuneTypeEnum runeType)
        {
            return new Rune(runeType);
        }
    }
}