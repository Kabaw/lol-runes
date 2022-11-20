using LoLRunes.Domain.Models;
using LoLRunes.LeagueClienteCommunication.Strategies.Interfaces;
using LoLRunes.Shared.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Threading.Tasks;
using PoniLCU;
using static PoniLCU.LeagueClient;
using LoLRunes.Shared.Dtos;
using LoLRunes.Infra;
using LoLRunes.Shared.ScriptableObjects;

namespace LoLRunes.LeagueClienteCommunication.Strategies.LCU.Services
{
    public class LcuRuneService : ILccRuneStrategy
    {
        private readonly string RUNE_PAGE_NAME = "LolRunes";

        private LeagueClient leagueClient;
        private LcuRuneIdConfig lcuRuneIdConfig;

        public LcuRuneService(IInspectorDataProvider inspectorDataProvider)
        {
            leagueClient = new LeagueClient(credentials.cmd);
            lcuRuneIdConfig = inspectorDataProvider.lcuRuneIdConfig;
        }

        public void ApplyRunePage(RunePage runePage)
        {
            AssyncOperationProvider.instance.RunAsync(ApplyRunePageProcess(runePage));
        }

        private IEnumerator ApplyRunePageProcess(RunePage runePage)
        {
            var task = CreateRunePage();

            while (!task.IsCompleted)
                yield return null;

            task = ApplyRunesToPage(runePage);

            while (!task.IsCompleted)
                yield return null;
        }

        private async Task CreateRunePage()
        {
            var data = await leagueClient.Request(requestMethod.GET, "/lol-perks/v1/inventory");
            var invertoryInfo = JObject.Parse(data);

            if (!(bool)invertoryInfo["isCustomPageCreationUnlocked"]!)
                return;

            data = await leagueClient.Request(requestMethod.GET, "/lol-perks/v1/pages");
            var pages = JArray.Parse(data);

            var pageIndex = -1;

            for (int i = 0; i < pages.Count; i++)
            {
                var name = pages[i].Value<string>("name");

                if (name is null)
                    continue;
                else if (name == RUNE_PAGE_NAME)
                {
                    pageIndex = i;
                    break;
                }
            }

            string pageId = null;
            if (pageIndex < 0)
            {
                if (!(bool)invertoryInfo["canAddCustomPage"]!)
                {
                    data = await leagueClient.Request(requestMethod.GET, "/lol-perks/v1/currentpage");
                    var currentPage = JObject.Parse(data);
                    pageId = currentPage["id"]!.ToString();
                }
            }
            else
            {
                pageId = pages[pageIndex].Value<string>("id")!;
            }

            if (pageId is not null)
                await leagueClient.Request(requestMethod.DELETE, "/lol-perks/v1/pages/" + pageId);
        }

        private async Task ApplyRunesToPage(RunePage runePage)
        {
            var lcuRunePage = ExtractLcuRunePage(runePage);

            var body = JsonConvert.SerializeObject(new
            {
                name = RUNE_PAGE_NAME,
                primaryStyleId = (int)runePage.MainPath.RuneType,
                subStyleId = (int)runePage.SidePath.RuneType,
                selectedPerkIds = new int[]
                {
                    lcuRunePage.KeyStone,
                    lcuRunePage.MainPathRune_01,
                    lcuRunePage.MainPathRune_02,
                    lcuRunePage.MainPathRune_03,
                    lcuRunePage.SidePathRune_01,
                    lcuRunePage.SidePathRune_02,
                    lcuRunePage.RuneShardAttack,
                    lcuRunePage.RuneShardDefence,
                    lcuRunePage.RuneShardFlex
                },
                current = true
            });

            var request = await leagueClient.Request(requestMethod.POST, "lol-perks/v1/pages", body);
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
    }
}