using LoLRunes.CustumData;
using LoLRunes.Domain.Models;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LoLRunes.Infra.Core
{
    public class RunePageRepository
    {
        private static int NEXT_ID = -1;

        private static readonly string RUNE_PAGES_FILE_NAME = "rune_pages.txt";

        public RunePageRepository()
        {
            if(NEXT_ID < 0)
            {
                CalculeNextID();
            }
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
            catch (Exception)
            {
                throw new Exception("Error when attempting to 'SAVE' the rune page data.");
            }
        }

        public List<RunePage> ReadAll()
        {
            string json;
            string runePageFilePath = UnityEngine.Application.persistentDataPath + "/" + RUNE_PAGES_FILE_NAME;            

            try
            {
                json = File.ReadAllText(runePageFilePath);

                List<RunePage> runePages = JsonUtility.FromJson<List<RunePage>>(json);

                return runePages;
            }
            catch (Exception)
            {
                throw new Exception("Error when attempting to 'READ' the calibration data.");
            }
        }

        public void Edit(RunePage runePage)
        {
            List<RunePage> runePages = ReadAll();

            int runePageIndex = runePages.FindIndex(r => r.id == runePage.id);

            runePages[runePageIndex] = runePage;

            try
            {
                SaveMany(runePages);
            }
            catch (Exception)
            {
                throw new Exception("Error when attempting to 'EDIT' the rune page data with ID: " + runePage.id);
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
            List<RunePage> runePages = ReadAll();

            NEXT_ID = runePages.Max(r => r.id) + 1;
        }
    }
}