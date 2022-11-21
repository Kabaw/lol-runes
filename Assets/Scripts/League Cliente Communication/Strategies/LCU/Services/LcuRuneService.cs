using LoLRunes.Domain.Models;
using LoLRunes.Infra;
using LoLRunes.LeagueClienteCommunication.Strategies.Interfaces;
using LoLRunes.LeagueClienteCommunication.Strategies.LCU.Repositories;
using LoLRunes.Shared.Dtos;
using LoLRunes.Shared.ScriptableObjects;
using LoLRunes.Shared.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Threading.Tasks;

namespace LoLRunes.LeagueClienteCommunication.Strategies.LCU.Services
{
    public class LcuRuneService : ILccRuneStrategy
    {
        private readonly string RUNE_PAGE_NAME = "LolRunes";
        private ILcuRepository lcuRepository;
        private LcuRuneIdConfig lcuRuneIdConfig;

        public LcuRuneService(ILcuRepository lcuRepository, IInspectorDataProvider inspectorDataProvider)
        {
            lcuRuneIdConfig = inspectorDataProvider.lcuRuneIdConfig;
            this.lcuRepository = lcuRepository;
        }

        public void ApplyRunePage(RunePage runePage)
        {
            AssyncOperationProvider.instance.RunAsync(ApplyRunePageProcess(runePage));
        }

        public LcuRunePage ExtractLcuRunePage(RunePage runePage)
        {
            return new LcuRunePage(runePage.Name,
                lcuRuneIdConfig.lcuIdMapping[runePage.MainPath.RuneType],
                lcuRuneIdConfig.lcuIdMapping[runePage.SidePath.RuneType],
                lcuRuneIdConfig.lcuIdMapping[runePage.KeyStone.RuneType],
                lcuRuneIdConfig.lcuIdMapping[runePage.MainPathRune_01.RuneType],
                lcuRuneIdConfig.lcuIdMapping[runePage.MainPathRune_02.RuneType],
                lcuRuneIdConfig.lcuIdMapping[runePage.MainPathRune_03.RuneType],
                lcuRuneIdConfig.lcuIdMapping[runePage.SidePathRune_01.RuneType],
                lcuRuneIdConfig.lcuIdMapping[runePage.SidePathRune_02.RuneType],
                lcuRuneIdConfig.lcuIdMapping[runePage.RuneShardAttack.RuneType],
                lcuRuneIdConfig.lcuIdMapping[runePage.RuneShardDefence.RuneType],
                lcuRuneIdConfig.lcuIdMapping[runePage.RuneShardFlex.RuneType]);
        }

        private IEnumerator ApplyRunePageProcess(RunePage runePage)
        {
            lcuRepository.ApplyRunePage(ExtractLcuRunePage(runePage));
            yield return null;
        }
    }
}