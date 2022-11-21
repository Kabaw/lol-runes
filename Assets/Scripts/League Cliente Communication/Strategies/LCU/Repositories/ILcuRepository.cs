using LoLRunes.Domain.Models;
using LoLRunes.Shared.Dtos;

namespace LoLRunes.LeagueClienteCommunication.Strategies.LCU.Repositories
{
    public interface ILcuRepository
    {
        public void ApplyRunePage(LcuRunePage runePage);
    }
}