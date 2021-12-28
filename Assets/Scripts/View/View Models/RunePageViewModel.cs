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
    }
}