using LoLRunes.Domain.Models;
using LoLRunes.Domain.Commands;
using LoLRunes.ScriptableObjects;
using LoLRunes.Program.Managers;

namespace LoLRunes.Domain.Services
{
    public class RunePageService
    {
        public RunePageService()
        {
            
        }

        public RunePage Instantiate(CreateRunePageCommand command)
        {
            return new RunePage(command.MainPath, command.SidePath, command.KeyStone, command.MainPathRune_01,
                command.MainPathRune_02, command.MainPathRune_03, command.SidePathRune_01, command.SidePathRune_02,
                command.RuneShardAttack, command.RuneShardFlex, command.RuneShardDefence);
        }
    }
}