using Assets.Scripts.Shared.Dtos;
using LoLRunes.Shared.Dtos;
using System.Drawing;
using UnityEngine;

namespace LoLRunes.Shared.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LcuRuneIdConfig_xx", menuName = "Scriptable Objects/LCU/LcuRuneIdConfig")]
    public class LcuRuneIdConfig : ScriptableObject
    {
        [Header("Path Runes")]
        public LcuRune precision;
        public LcuRune domination;
        public LcuRune sorcery;
        public LcuRune resolve;
        public LcuRune inspiration;

        #region Precision
        [Header("Precision")]
        public LcuRune precisionKeyStone_01;
        public LcuRune precisionKeyStone_02;
        public LcuRune precisionKeyStone_03;
        public LcuRune precisionKeyStone_04;
        
        public LcuRune precisionRuneSlot_01;
        public LcuRune precisionRuneSlot_02;
        public LcuRune precisionRuneSlot_03;
        public LcuRune precisionRuneSlot_04;
        public LcuRune precisionRuneSlot_05;
        public LcuRune precisionRuneSlot_06;
        public LcuRune precisionRuneSlot_07;
        public LcuRune precisionRuneSlot_08;
        public LcuRune precisionRuneSlot_09;
        #endregion

        #region Domination
        [Header("Domination")]
        public LcuRune dominationKeyStone_01;
        public LcuRune dominationKeyStone_02;
        public LcuRune dominationKeyStone_03;
        public LcuRune dominationKeyStone_04;
        
        public LcuRune dominationRuneSlot_01;
        public LcuRune dominationRuneSlot_02;
        public LcuRune dominationRuneSlot_03;
        public LcuRune dominationRuneSlot_04;
        public LcuRune dominationRuneSlot_05;
        public LcuRune dominationRuneSlot_06;
        public LcuRune dominationRuneSlot_07;
        public LcuRune dominationRuneSlot_08;
        public LcuRune dominationRuneSlot_09;
        public LcuRune dominationRuneSlot_10;
        #endregion

        #region Sorcery
        [Header("Sorcery")]
        public LcuRune sorceryKeyStone_01;
        public LcuRune sorceryKeyStone_02;
        public LcuRune sorceryKeyStone_03;
        
        public LcuRune sorceryRuneSlot_01;
        public LcuRune sorceryRuneSlot_02;
        public LcuRune sorceryRuneSlot_03;
        public LcuRune sorceryRuneSlot_04;
        public LcuRune sorceryRuneSlot_05;
        public LcuRune sorceryRuneSlot_06;
        public LcuRune sorceryRuneSlot_07;
        public LcuRune sorceryRuneSlot_08;
        public LcuRune sorceryRuneSlot_09;
        #endregion

        #region Resolve
        [Header("Resolve")]
        public LcuRune resolveKeyStone_01;
        public LcuRune resolveKeyStone_02;
        public LcuRune resolveKeyStone_03;
                       
        public LcuRune resolveRuneSlot_01;
        public LcuRune resolveRuneSlot_02;
        public LcuRune resolveRuneSlot_03;
        public LcuRune resolveRuneSlot_04;
        public LcuRune resolveRuneSlot_05;
        public LcuRune resolveRuneSlot_06;
        public LcuRune resolveRuneSlot_07;
        public LcuRune resolveRuneSlot_08;
        public LcuRune resolveRuneSlot_09;
        #endregion

        #region Inspiration
        [Header("Inspiration")]
        public LcuRune inspirationKeyStone_01;
        public LcuRune inspirationKeyStone_02;
        public LcuRune inspirationKeyStone_03;
        
        public LcuRune inspirationRuneSlot_01;
        public LcuRune inspirationRuneSlot_02;
        public LcuRune inspirationRuneSlot_03;
        public LcuRune inspirationRuneSlot_04;
        public LcuRune inspirationRuneSlot_05;
        public LcuRune inspirationRuneSlot_06;
        public LcuRune inspirationRuneSlot_07;
        public LcuRune inspirationRuneSlot_08;
        public LcuRune inspirationRuneSlot_09;
        #endregion

        #region Rune Shards
        [Header("Rune Shards")]
        public LcuRune shardSlot_01;
        public LcuRune shardSlot_02;
        public LcuRune shardSlot_03;
        public LcuRune shardSlot_04;
        public LcuRune shardSlot_05;
        public LcuRune shardSlot_06;
        public LcuRune shardSlot_07;
        public LcuRune shardSlot_08;
        public LcuRune shardSlot_09;
        #endregion
    }
}