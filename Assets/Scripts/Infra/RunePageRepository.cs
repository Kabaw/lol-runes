using LoLRunes.CustumData;
using LoLRunes.Domain.Models;
using System;
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
        private static readonly string RUNE_PAGES_FILE_NAME = "rune_pages.txt";

        public RunePageRepository() { }

        public void SaveRunePages(RunePage runePage)
        {
            string runePageFilePath = UnityEngine.Application.persistentDataPath + "/" + RUNE_PAGES_FILE_NAME;
            string json = JsonUtility.ToJson(runePage);

            try
            {
                File.WriteAllText(runePageFilePath, json);
            }
            catch (Exception)
            {
                throw new Exception("Error when attempting to save the rune page data.");
            }            
        }

        public List<RunePage> ReadRunePages()
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
                throw new Exception("Error when attempting to read the calibration data.");
            }
        }
    }
}