using LoLRunes.Domain.Models;
using LoLRunes.Infra;
using LoLRunes.LeagueClienteCommunication.Strategies.LCU.Repositories;
using LoLRunes.Shared.Dtos;
using System.Diagnostics;

namespace Assets.Scripts.Infra.Lcu
{
    public class LcuRepository : ILcuRepository
    {
        private IInspectorDataProvider inspectorDataProvider;

        public LcuRepository(IInspectorDataProvider inspectorDataProvider)
        {
            this.inspectorDataProvider = inspectorDataProvider;
        }

        public void ApplyRunePage(LcuRunePage runePage)
        {
            using(var process = new Process())
            {
                process.StartInfo.FileName = inspectorDataProvider.lcuEnginePath;
                process.Start();
            }            
        }
    }
}