using LoLRunes.Domain.Models;
using LoLRunes.LeagueClienteCommunication.Interfaces;
using LoLRunes.LeagueClienteCommunication.Strategies.Interfaces;
using LoLRunes.LeagueClienteCommunication.Strategies.WindowInteraction.Services;

namespace LoLRunes.LeagueClienteCommunication.Strategies.LCU.Services
{
    public class LccRuneService : ILccRuneService
    {
        private LcuRuneService lcuRuneService;
        private LeagueWindowInteractionService leagueWindowInteractionService;

        private ILccRuneStrategy currentStrategy;

        public LccRuneService(LcuRuneService lcuRuneService, LeagueWindowInteractionService leagueWindowInteractionService)
        {
            this.lcuRuneService = lcuRuneService;
            this.leagueWindowInteractionService = leagueWindowInteractionService;

            currentStrategy = this.lcuRuneService;
        }

        public void ApplyRunePage(RunePage runePage)
        {
            currentStrategy.ApplyRunePage(runePage);
        }
    }
}