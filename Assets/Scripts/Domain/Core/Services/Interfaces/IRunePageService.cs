using LoLRunes.Domain.Commands;
using LoLRunes.Domain.Models;
using System.Collections.Generic;

namespace LoLRunes.Domain.Services
{
    public interface IRunePageService
    {
        RunePage Edit(RunePage runePage, EditRunePageCommand command);
        RunePage Instantiate(CreateRunePageCommand command);
        RunePage Read(int id);
        List<RunePage> ReadAll();
        RunePage ReadByName(string name);
        RunePage Save(RunePage runePage);
    }
}