using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoLRunes.View.ViewModel
{
    public class RunePageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RuneViewModel MainPath { get; set; }
        public RuneViewModel SidePath { get; set; }

        public RuneViewModel KeyStone { get; set; }

        public RuneViewModel MainPathRune_01 { get; set; }
        public RuneViewModel MainPathRune_02 { get; set; }
        public RuneViewModel MainPathRune_03 { get; set; }

        public RuneViewModel SidePathRune_01 { get; set; }
        public RuneViewModel SidePathRune_02 { get; set; }

        public RuneViewModel RuneShardAttack { get; set; }
        public RuneViewModel RuneShardFlex { get; set; }
        public RuneViewModel RuneShardDefence { get; set; }        

        public RunePageViewModel()
        {
            Name = "Rune Page";
        }

        public RunePageViewModel DeepCopy()
        {
            RunePageViewModel runePage = new RunePageViewModel();

            runePage.Id = Id;
            runePage.Name = string.Copy(Name);
            runePage.MainPath = MainPath.DeepCopy();
            runePage.SidePath = SidePath.DeepCopy();
            runePage.KeyStone = KeyStone.DeepCopy();
            runePage.MainPathRune_01 = MainPathRune_01.DeepCopy();
            runePage.MainPathRune_02 = MainPathRune_02.DeepCopy();
            runePage.MainPathRune_03 = MainPathRune_03.DeepCopy();
            runePage.SidePathRune_01 = SidePathRune_01.DeepCopy();
            runePage.SidePathRune_02 = SidePathRune_02.DeepCopy();
            runePage.RuneShardAttack = RuneShardAttack.DeepCopy();
            runePage.RuneShardFlex = RuneShardFlex.DeepCopy();
            runePage.RuneShardDefence = RuneShardDefence.DeepCopy();

            return runePage;
        }
    }
}