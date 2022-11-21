using LoLRunes.Domain.Models;
using LoLRunes.Infra;
using LoLRunes.LeagueClienteCommunication.Strategies.LCU.Repositories;
using LoLRunes.Shared.Dtos;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

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
                var port = GetFreeTcpPort();

                process.StartInfo.FileName = inspectorDataProvider.lcuEnginePath + "/" + inspectorDataProvider.lcuEngineFileName;
                //process.StartInfo.Arguments
                process.Start();
            }            
        }

        private int GetFreeTcpPort()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }
    }
}