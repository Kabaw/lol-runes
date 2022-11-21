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
        private IInspectorDataProvider inspectorDataProvider;

        public LcuRuneService(ILcuRepository lcuRepository, IInspectorDataProvider inspectorDataProvider)
        {
            this.lcuRepository = lcuRepository;
            this.inspectorDataProvider = inspectorDataProvider;
        }

        public void ApplyRunePage(RunePage runePage)
        {
            AssyncOperationProvider.instance.RunAsync(ApplyRunePageProcess(runePage));
        }

        public LcuRunePage ExtractLcuRunePage(RunePage runePage)
        {
            return new LcuRunePage(runePage.Name,
                inspectorDataProvider.lcuIdMapping[runePage.MainPath.RuneType],
                inspectorDataProvider.lcuIdMapping[runePage.SidePath.RuneType],
                inspectorDataProvider.lcuIdMapping[runePage.KeyStone.RuneType],
                inspectorDataProvider.lcuIdMapping[runePage.MainPathRune_01.RuneType],
                inspectorDataProvider.lcuIdMapping[runePage.MainPathRune_02.RuneType],
                inspectorDataProvider.lcuIdMapping[runePage.MainPathRune_03.RuneType],
                inspectorDataProvider.lcuIdMapping[runePage.SidePathRune_01.RuneType],
                inspectorDataProvider.lcuIdMapping[runePage.SidePathRune_02.RuneType],
                inspectorDataProvider.lcuIdMapping[runePage.RuneShardAttack.RuneType],
                inspectorDataProvider.lcuIdMapping[runePage.RuneShardDefence.RuneType],
                inspectorDataProvider.lcuIdMapping[runePage.RuneShardFlex.RuneType]);
        }

        private IEnumerator ApplyRunePageProcess(RunePage runePage)
        {
            lcuRepository.ApplyRunePage(ExtractLcuRunePage(runePage));
            yield return null;
        }
    }
}