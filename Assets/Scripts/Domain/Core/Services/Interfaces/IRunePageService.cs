using LoLRunes.Domain.Models;
using LoLRunes.Domain.Services.Commands;
using System.Collections.Generic;

namespace LoLRunes.Domain.Services.Interfaces
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