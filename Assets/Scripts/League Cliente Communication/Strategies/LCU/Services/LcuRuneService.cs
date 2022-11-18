using LoLRunes.Domain.Models;
using LoLRunes.LeagueClienteCommunication.Strategies.Interfaces;
using LoLRunes.Shared.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PoniLCU;
using System.Collections;
using System.Threading.Tasks;
using static PoniLCU.LeagueClient;

namespace LoLRunes.LeagueClienteCommunication.Strategies.LCU.Services
{
    public class LcuRuneService : ILccRuneStrategy
    {
        private readonly string RUNE_PAGE_NAME = "LolRunes";

        private LeagueClient leagueClient;

        public LcuRuneService()
        {
            leagueClient = new LeagueClient(credentials.cmd);
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

            //Console.WriteLine($"Pages used {pages.Count}. Pages owned: {invertoryInfo["ownedPageCount"]}");

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
            var body = JsonConvert.SerializeObject(new
            {
                name = RUNE_PAGE_NAME,
                primaryStyleId = 8300,
                subStyleId = 8400,
                selectedPerkIds = new int[] { 8351, 8313, 8345, 8347, 8451, 8444, 5007, 5002, 5001 },
                current = true
            });

            var request = await leagueClient.Request(requestMethod.POST, "lol-perks/v1/pages", body);
        }
    }
}