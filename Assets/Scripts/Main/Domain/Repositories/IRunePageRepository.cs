using LoLRunes.Domain.Models;
using System.Collections.Generic;

namespace LoLRunes.Domain.Repositories
{
    public interface IRunePageRepository
    {
        void Edit(RunePage runePage);
        void Insert(RunePage runePage);
        RunePage Read(int id);
        List<RunePage> ReadAll();
        RunePage ReadByName(string name);
        void SetId(object obj, int id);
    }
}