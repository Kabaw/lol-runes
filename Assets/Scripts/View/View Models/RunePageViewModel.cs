using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoLRunes.View.ViewModel
{
    public class RunePageViewModel
    {
        public RuneViewModel KeyStone { get; set; }

        public RuneViewModel mainPathRune_01 { get; set; }
        public RuneViewModel mainPathRune_02 { get; set; }
        public RuneViewModel mainPathRune_03 { get; set; }

        public RuneViewModel sidePathRune_01 { get; set; }
        public RuneViewModel sidePathRune_02 { get; set; }

        public RuneViewModel runeShardAttack { get; set; }
        public RuneViewModel runeShardFlex { get; set; }
        public RuneViewModel runeShardDefence { get; set; }        
    }
}