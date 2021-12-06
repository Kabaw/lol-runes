using LoLRunes.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace LoLRunes.Infra.Core
{
    public class RunePageRepository
    {
        private static int NEXT_ID = -1;

        private static readonly string RUNE_PAGES_FILE_NAME = "rune_pages.txt";

        public RunePageRepository()
        {
            CheckFilesExistance();
            CalculeNextID();
        }

        public void SetId(object obj, int id)
        {
            Type type = obj.GetType();

            PropertyInfo prop = type.GetProperty("id");

            prop.SetValue(obj, id);
        }

        public void Save(RunePage runePage)
        {
            List<RunePage> runePages = ReadAll();

            SetId(runePage, NEXT_ID);

            runePages.Add(runePage);

            try
            {
                SaveMany(runePages);

                NEXT_ID++;
            }
            catch (Exception error)
            {
                throw new Exception("Error when attempting to 'SAVE' the Rune page data.\n" + error.Message);
            }
        }

        public RunePage Read(int id)
        {
            List<RunePage> runePages = ReadAll();

            RunePage runePage = runePages.Where(r => r.Id == id).FirstOrDefault();

            return runePage;
        }

        public RunePage Read(string name)
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

                List<RunePage> runePages = JsonUtility.FromJson<List<RunePage>>(json);

                if (runePages == null)
                    runePages = new List<RunePage>();

                return runePages;
            }
            catch (Exception error)
            {
                throw new Exception("Error when attempting to 'READ' the Rune Page data.\n" + error.Message);
            }
        }

        public void Edit(RunePage runePage)
        {
            List<RunePage> runePages = ReadAll();

            int runePageIndex = runePages.FindIndex(r => r.Id == runePage.Id);

            runePages[runePageIndex] = runePage;

            try
            {
                SaveMany(runePages);
            }
            catch (Exception error)
            {
                throw new Exception("Error when attempting to 'EDIT' the Rune Page data with ID: " + runePage.Id + "\n" + error.Message);
            }           
        }

        private void SaveMany(List<RunePage> runePages)
        {
            string runePageFilePath = UnityEngine.Application.persistentDataPath + "/" + RUNE_PAGES_FILE_NAME;
            string json = JsonUtility.ToJson(runePages);

            File.WriteAllText(runePageFilePath, json);
        }

        private void CalculeNextID()
        {
            if (NEXT_ID >= 0)
                return;

            List<RunePage> runePages = ReadAll();            

            NEXT_ID = runePages.Count == 0 ? 1 : runePages.Max(r => r.Id) + 1;
        }

        private void CheckFilesExistance()
        {
            if (!File.Exists(UnityEngine.Application.persistentDataPath + "/" + RUNE_PAGES_FILE_NAME))
                File.Create(UnityEngine.Application.persistentDataPath + "/" + RUNE_PAGES_FILE_NAME);
        }
    }
}