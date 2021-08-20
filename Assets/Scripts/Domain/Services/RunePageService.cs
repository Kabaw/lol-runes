using LoLRunes.Domain.Models;
using LoLRunes.Domain.Commands;

namespace LoLRunes.Domain.Services
{
    public class RunePageService
    {
        //Aplica a configuração de runas na janela do LOL
        public void ApplyRunePage(RunePage runePage)
        {

        }

        private RunePage Instantiate(CreateRunePageCommand command)
        {
            return new RunePage(command.MainPath, command.SidePath, command.KeyStone, command.MainPathRune_01,
                command.MainPathRune_02, command.MainPathRune_03, command.SidePathRune_01, command.SidePathRune_02,
                command.RuneShardAttack, command.RuneShardFlex, command.RuneShardDefence);
        }
    }
}