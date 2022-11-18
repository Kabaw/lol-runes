using LoLRunes.Domain.Models;
using LoLRunes.LeagueClienteCommunication.Strategies.Interfaces;
using LoLRunes.LeagueClienteCommunication.Strategies.WindowInteraction.Services;
using LoLRunes.LeagueClienteCommunication.Strategies.WindowInteraction.Services.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            currentStrategy = leagueWindowInteractionService;
        }

        public void ApplyRunePage(RunePage runePage)
        {
            currentStrategy.ApplyRunePage(runePage);
        }
    }
}