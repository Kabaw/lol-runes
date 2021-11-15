using LoLRunes.Domain.Models;
using LoLRunes.Enumerators;
using LoLRunes.Enumerators.Extensions;
using LoLRunes.Program.Managers;
using LoLRunes.ScriptableObjects;

namespace LoLRunes.Domain.Services
{
    public class RuneService
    {
        public RuneService() { }

        public Rune Instantiate(RuneTypeEnum runeType)
        {
            return new Rune(runeType);
        }
    }
}