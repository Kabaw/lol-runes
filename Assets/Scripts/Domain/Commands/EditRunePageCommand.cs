using LoLRunes.Domain.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoLRunes.Domain.Commands
{
    public class EditRunePageCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BuildLink { get; set; }

        public Rune MainPath { get; set; }
        public Rune SidePath { get; set; }

        public Rune KeyStone { get; set; }

        public Rune MainPathRune_01 { get; set; }
        public Rune MainPathRune_02 { get; set; }
        public Rune MainPathRune_03 { get; set; }

        public Rune SidePathRune_01 { get; set; }
        public Rune SidePathRune_02 { get; set; }

        public Rune RuneShardAttack { get; set; }
        public Rune RuneShardFlex { get; set; }
        public Rune RuneShardDefence { get; set; }
    }
}
