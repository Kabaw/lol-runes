using LolRunes.Domain.Core.Exceptions;
using LoLRunes.Enumerators;
using Newtonsoft.Json;
using System;

namespace LoLRunes.Domain.Models
{
    public class RunePage
    {
        public int Id { get; private set; }        
        public string Name { get; internal set; }

        public Rune MainPath { get; internal set; }
        public Rune SidePath { get; internal set; }

        public Rune KeyStone { get; internal set; }

        public Rune MainPathRune_01 { get; internal set; }
        public Rune MainPathRune_02 { get; internal set; }
        public Rune MainPathRune_03 { get; internal set; }

        public Rune SidePathRune_01 { get; internal set; }
        public Rune SidePathRune_02 { get; internal set; }

        public Rune RuneShardAttack { get; internal set; }
        public Rune RuneShardFlex { get; internal set; }
        public Rune RuneShardDefence { get; internal set; }

        #region Json Constructor
        [JsonConstructor]
        public RunePage(int id, string name, Rune mainPath, Rune sidePath, Rune keyStone, Rune mainPathRune_01, Rune mainPathRune_02,
            Rune mainPathRune_03, Rune sidePathRune_01, Rune sidePathRune_02, Rune runeShardAttack, Rune runeShardFlex, Rune runeShardDefence)
        {
            Id = id;

            Name = name;

            MainPath = mainPath;
            SidePath = sidePath;

            KeyStone = keyStone;

            MainPathRune_01 = mainPathRune_01;
            MainPathRune_02 = mainPathRune_02;
            MainPathRune_03 = mainPathRune_03;

            SidePathRune_01 = sidePathRune_01;
            SidePathRune_02 = sidePathRune_02;

            RuneShardAttack = runeShardAttack;
            RuneShardFlex = runeShardFlex;
            RuneShardDefence = runeShardDefence;
        }
        #endregion

        public RunePage(string name, Rune mainPath, Rune sidePath, Rune keyStone, Rune mainPathRune_01, Rune mainPathRune_02,
            Rune mainPathRune_03, Rune sidePathRune_01, Rune sidePathRune_02, Rune runeShardAttack, Rune runeShardFlex, Rune runeShardDefence)
        {
            Name = name;

            MainPath = mainPath;
            SidePath = sidePath;

            KeyStone = keyStone;

            MainPathRune_01 = mainPathRune_01;
            MainPathRune_02 = mainPathRune_02;
            MainPathRune_03 = mainPathRune_03;

            SidePathRune_01 = sidePathRune_01;
            SidePathRune_02 = sidePathRune_02;

            RuneShardAttack = runeShardAttack;
            RuneShardFlex = runeShardFlex;
            RuneShardDefence = runeShardDefence;

            EvaluateModel();
        }

        private void EvaluateModel()
        {
            if (Name == null)
                throw new BusinessLogicException("No Name", "The Rune Page name was not informed!!");

            if (MainPath == null ||
                SidePath == null ||
                KeyStone == null ||
                MainPathRune_01 == null ||
                MainPathRune_02 == null ||
                MainPathRune_03 == null ||
                SidePathRune_01 == null ||
                SidePathRune_02 == null ||
                RuneShardAttack == null ||
                RuneShardFlex == null ||
                RuneShardDefence == null)
            {
                throw new BusinessLogicException("Incomplete Page", "Not all runes of the page were informed!");
            }
        }
    }
}