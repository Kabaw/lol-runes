using LoLRunes.Shared.Enums;

namespace LoLRunes.Shared.Dtos
{
    public class LcuRunePage
    {
        public int Name { get; internal set; }

        public int MainPath { get; internal set; }
        public int SidePath { get; internal set; }

        public int KeyStone { get; internal set; }

        public int MainPathRune_01 { get; internal set; }
        public int MainPathRune_02 { get; internal set; }
        public int MainPathRune_03 { get; internal set; }

        public int SidePathRune_01 { get; internal set; }
        public int SidePathRune_02 { get; internal set; }

        public int RuneShardAttack { get; internal set; }
        public int RuneShardFlex { get; internal set; }
        public int RuneShardDefence { get; internal set; }

        public LcuRunePage(string name, string mainPath, string sidePath, string keyStone, string mainPathRune_01, string mainPathRune_02, string mainPathRune_03,
            string sidePathRune_01,string sidePathRune_02, string runeShardAttack, string runeShardFlex, string runeShardDefence)
        {
            Name = int.Parse(name);
            MainPath = int.Parse(mainPath);
            SidePath = int.Parse(sidePath);
            KeyStone = int.Parse(keyStone);
            MainPathRune_01 = int.Parse(mainPathRune_01);
            MainPathRune_02 = int.Parse(mainPathRune_02);
            MainPathRune_03 = int.Parse(mainPathRune_03);
            SidePathRune_01 = int.Parse(sidePathRune_01);
            SidePathRune_02 = int.Parse(sidePathRune_02);
            RuneShardAttack = int.Parse(runeShardAttack);
            RuneShardFlex = int.Parse(runeShardFlex);
            RuneShardDefence = int.Parse(runeShardDefence);
        }
    }
}