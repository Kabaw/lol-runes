using LoLRunes.Domain.Interfaces;
using LoLRunes.Domain.Models;
using LoLRunes.Enumerators;

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