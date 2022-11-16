using LoLRunes.Domain.Repositories;
using LoLRunes.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace LoLRunes.Infra.Core
{
    public class RunePageRepository : IRunePageRepository
    {
        private static int NEXT_ID = 0;

        private static readonly string RUNE_PAGES_FILE_NAME = "rune_pages.txt";
        private static readonly string RUNE_PAGES_FILE_PATH = UnityEngine.Application.persistentDataPath + "/" + RUNE_PAGES_FILE_NAME;

        public RunePageRepository()
        {
            CheckFilesExistance();
            CalculeNextID();
        }

        public void SetId(object obj, int id)
        {
            Type type = obj.GetType();

            PropertyInfo prop = type.GetProperty("Id");

            prop.SetValue(obj, id);
        }

        public void Insert(RunePage runePage)
        {
            List<RunePage> runePages = ReadAll();

            SetId(runePage, NEXT_ID);

            runePages.Add(runePage);

            try
            {
                InsertMany(runePages);

                NEXT_ID++;
            }
            catch (Exception error)
            {
                throw new IOException("Error when attempting to 'INSERT' the Rune page data.\n" + error.Message);
            }
        }

        public RunePage Read(int id)
        {
            List<RunePage> runePages = ReadAll();

            RunePage runePage = runePages.Where(r => r.Id == id).FirstOrDefault();

            return runePage;
        }

        public RunePage ReadByName(string name)
        {
            List<RunePage> runePages = ReadAll();

            RunePage runePage = runePages.Where(r => r.Name == name).FirstOrDefault();

            return runePage;
        }

        public List<RunePage> ReadAll()
        {
            string json;
            string runePageFilePath = UnityEngine.Application.persistentDataPath + "/" + RUNE_PAGES_FILE_NAME;

            try
            {
                json = File.ReadAllText(runePageFilePath);

                List<RunePage> runePages = JsonConvert.DeserializeObject<List<RunePage>>(json);

                if (runePages == null)
                    runePages = new List<RunePage>();

                return runePages;
            }
            catch (Exception error)
            {
                throw new IOException("Error when attempting to 'READ' the Rune Page data.\n" + error.Message);
            }
        }

        public void Edit(RunePage runePage)
        {
            List<RunePage> runePages = ReadAll();

            int runePageIndex = runePages.FindIndex(r => r.Id == runePage.Id);

            runePages[runePageIndex] = runePage;

            try
            {
                InsertMany(runePages);
            }
            catch (Exception error)
            {
                throw new IOException("Error when attempting to 'EDIT' the Rune Page data with ID: " + runePage.Id + "\n" + error.Message);
            }
        }

        private void InsertMany(List<RunePage> runePages)
        {
            string runePageFilePath = UnityEngine.Application.persistentDataPath + "/" + RUNE_PAGES_FILE_NAME;
            string json = JsonConvert.SerializeObject(runePages);

            File.WriteAllText(runePageFilePath, json);
        }

        private void CalculeNextID()
        {
            if (NEXT_ID > 0)
                return;

            List<RunePage> runePages = ReadAll();

            NEXT_ID = runePages.Count == 0 ? 1 : runePages.Max(r => r.Id) + 1;
        }

        private void CheckFilesExistance()
        {
            if (File.Exists(RUNE_PAGES_FILE_PATH))
                return;

            FileStream stream = File.Create(RUNE_PAGES_FILE_PATH);

            while (!File.Exists(RUNE_PAGES_FILE_PATH)) { }

            stream.Close();
        }
    }
}