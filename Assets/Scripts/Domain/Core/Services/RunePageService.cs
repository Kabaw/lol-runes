using LolRunes.Domain.Core.Exceptions;
using LoLRunes.Domain.Commands;
using LoLRunes.Domain.Models;
using LoLRunes.Domain.Repositories;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace LoLRunes.Domain.Services
{
    public class RunePageService : IRunePageService
    {
        IRunePageRepository runePageRepository;

        [Inject]
        public RunePageService(IRunePageRepository runePageRepository)
        {
            this.runePageRepository = runePageRepository;
        }

        public RunePage Instantiate(CreateRunePageCommand command)
        {
            return new RunePage(command.Name, command.BuildLink, command.MainPath, command.SidePath, command.KeyStone, command.MainPathRune_01,
                command.MainPathRune_02, command.MainPathRune_03, command.SidePathRune_01, command.SidePathRune_02,
                command.RuneShardAttack, command.RuneShardFlex, command.RuneShardDefence);
        }

        public RunePage Save(RunePage runePage)
        {
            if (runePage == null)
                throw new InvalidOperationException("Insert: RunePage objetc is null or dosen't have an ID");

            if (runePage.Id > 0)
                throw new InvalidOperationException("Insert: Can't insert this RunePage, it alredy have an ID");

            RunePage page = runePageRepository.ReadByName(runePage.Name);

            if (page != null)
                throw new BusinessLogicException("Name already used", "There is already another Rune Page with the same name!");

            runePageRepository.Insert(runePage);

            return runePage;
        }

        public RunePage Read(int id)
        {
            RunePage runePage = runePageRepository.Read(id);

            if (runePage == null)
                throw new Exception("Unable to find the rune page with ID: '" + id + "'");

            return runePage;
        }

        public RunePage ReadByName(string name)
        {
            RunePage runePage = runePageRepository.ReadByName(name);

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
            if (runePage == null || runePage.Id < 1)
                throw new BusinessLogicException("RunePage objetc is null or dosen't have an ID", false);

            RunePage page = runePageRepository.ReadByName(command.Name);

            if (page != null && page.Id != runePage.Id)
                throw new BusinessLogicException("Name already used", "There is already another Rune Page with the same name!");

            runePage.Name = command.Name;
            runePage.BuildLink = command.BuildLink;
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