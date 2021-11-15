using LoLRunes.Domain.Models;
using LoLRunes.Domain.Commands;
using LoLRunes.ScriptableObjects;
using LoLRunes.Program.Managers;
using LoLRunes.Infra.Core;
using System.Collections.Generic;
using System;

namespace LoLRunes.Domain.Services
{
    public class RunePageService
    {
        RunePageRepository runePageRepository;

        public RunePageService()
        {
            runePageRepository = new RunePageRepository();
        }

        public RunePage Instantiate(CreateRunePageCommand command)
        {
            return new RunePage(command.Name, command.MainPath, command.SidePath, command.KeyStone, command.MainPathRune_01,
                command.MainPathRune_02, command.MainPathRune_03, command.SidePathRune_01, command.SidePathRune_02,
                command.RuneShardAttack, command.RuneShardFlex, command.RuneShardDefence);
        }

        public RunePage Save(RunePage runePage)
        {
            runePageRepository.Save(runePage);

            return runePage;
        }

        public RunePage Read(int id)
        {
            RunePage runePage = runePageRepository.Read(id);

            if(runePage == null)
                throw new Exception("Unable to find the rune page with ID: '" + id + "'");

            return runePage;
        }

        public RunePage Read(string name)
        {
            RunePage runePage = runePageRepository.Read(name);

            if (runePage == null)
                throw new Exception("Unable to find the rune page with Name: '" + name + "'");

            return runePage;
        }

        public List<RunePage> ReadAll()
        {
            return runePageRepository.ReadAll();
        }

        public RunePage Edit(RunePage runePage, EditRunePageCommand command)
        {
            runePage.Name = command.Name;
            runePage.MainPath = command.MainPath;
            runePage.SidePath = command.SidePath;
            runePage.KeyStone = command.KeyStone;
            runePage.MainPathRune_01 = command.MainPathRune_01;
            runePage.MainPathRune_02 = command.MainPathRune_02;
            runePage.MainPathRune_03 = command.MainPathRune_03;
            runePage.SidePathRune_01 = command.SidePathRune_01;
            runePage.SidePathRune_02 = command.SidePathRune_02;
            runePage.RuneShardAttack = command.RuneShardAttack;
            runePage.RuneShardFlex = command.RuneShardFlex;
            runePage.RuneShardDefence = command.RuneShardDefence;

            runePageRepository.Edit(runePage);

            return runePage;
        }
    }
}