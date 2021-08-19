using LoLRunes.Enumerators;
using System;

namespace LoLRunes.Domain.Models
{
    public class RunePage
    {
        public Rune MainPath { get; private set; }
        public Rune SidePath { get; private set; }

        public Rune KeyStone { get; private set; }

        public Rune MainPathRune_01 { get; private set; }
        public Rune MainPathRune_02 { get; private set; }
        public Rune MainPathRune_03 { get; private set; }

        public Rune SidePathRune_01 { get; private set; }
        public Rune SidePathRune_02 { get; private set; }

        public Rune RuneShardAttack { get; private set; }
        public Rune RuneShardFlex { get; private set; }
        public Rune RuneShardDefence { get; private set; }

        public RunePage(Rune mainPath, Rune sidePath, Rune keyStone, Rune mainPathRune_01, Rune mainPathRune_02,
            Rune mainPathRune_03, Rune sidePathRune_01, Rune sidePathRune_02, Rune runeShardAttack, Rune runeShardFlex, Rune runeShardDefence)
        {
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

        private void EvaluateModel()
        {
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
                throw new InvalidOperationException("Some fields have null values");
            }
        }
    }
}