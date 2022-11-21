using Assets.Scripts.Shared.Dtos;
using LoLRunes.Shared.Enums;
using System.Collections.Generic;
using UnityEngine;

namespace LoLRunes.Shared.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LcuRuneIdConfig_xx", menuName = "Scriptable Objects/LCU/LcuRuneIdConfig")]
    public class LcuRuneIdConfig : ScriptableObject
    {
        #region Paths
        [Header("Path Runes")]
        [SerializeField] public LcuRune precision = new LcuRune("8000", RuneTypeEnum.PRECISION_PATH);
        [SerializeField] public LcuRune domination = new LcuRune("8100", RuneTypeEnum.DOMINATION_PATH);
        [SerializeField] public LcuRune sorcery;
        [SerializeField] public LcuRune resolve;
        [SerializeField] public LcuRune inspiration;
        #endregion

        #region Precision
        [Header("Precision")]
        [SerializeField] public LcuRune precisionKeyStone_01 = new LcuRune("8005", RuneTypeEnum.PRECISION_KEYSTONE_01);
        [SerializeField] public LcuRune precisionKeyStone_02;
        [SerializeField] public LcuRune precisionKeyStone_03;
        [SerializeField] public LcuRune precisionKeyStone_04;

        [SerializeField] public LcuRune precisionRuneSlot_01 = new LcuRune("9101", RuneTypeEnum.PRECISION_RUNE_SLOT_01);
        [SerializeField] public LcuRune precisionRuneSlot_02;
        [SerializeField] public LcuRune precisionRuneSlot_03;
        [SerializeField] public LcuRune precisionRuneSlot_04 = new LcuRune("9104", RuneTypeEnum.PRECISION_RUNE_SLOT_04);
        [SerializeField] public LcuRune precisionRuneSlot_05;
        [SerializeField] public LcuRune precisionRuneSlot_06;
        [SerializeField] public LcuRune precisionRuneSlot_07 = new LcuRune("8014", RuneTypeEnum.PRECISION_RUNE_SLOT_07);
        [SerializeField] public LcuRune precisionRuneSlot_08;
        [SerializeField] public LcuRune precisionRuneSlot_09;
        #endregion

        #region Domination
        [Header("Domination")]
        [SerializeField] public LcuRune dominationKeyStone_01 = new LcuRune("8112", RuneTypeEnum.DOMINATION_KEYSTONE_01);
        [SerializeField] public LcuRune dominationKeyStone_02;
        [SerializeField] public LcuRune dominationKeyStone_03;
        [SerializeField] public LcuRune dominationKeyStone_04;

        [SerializeField] public LcuRune dominationRuneSlot_01 = new LcuRune("8126", RuneTypeEnum.DOMINATION_RUNE_SLOT_01);
        [SerializeField] public LcuRune dominationRuneSlot_02;
        [SerializeField] public LcuRune dominationRuneSlot_03;
        [SerializeField] public LcuRune dominationRuneSlot_04 = new LcuRune("8136", RuneTypeEnum.DOMINATION_RUNE_SLOT_04);
        [SerializeField] public LcuRune dominationRuneSlot_05;
        [SerializeField] public LcuRune dominationRuneSlot_06;
        [SerializeField] public LcuRune dominationRuneSlot_07 = new LcuRune("8135", RuneTypeEnum.DOMINATION_RUNE_SLOT_07);
        [SerializeField] public LcuRune dominationRuneSlot_08;
        [SerializeField] public LcuRune dominationRuneSlot_09;
        [SerializeField] public LcuRune dominationRuneSlot_10;
        #endregion

        #region Sorcery
        [Header("Sorcery")]
        [SerializeField] public LcuRune sorceryKeyStone_01;
        [SerializeField] public LcuRune sorceryKeyStone_02;
        [SerializeField] public LcuRune sorceryKeyStone_03;

        [SerializeField] public LcuRune sorceryRuneSlot_01;
        [SerializeField] public LcuRune sorceryRuneSlot_02;
        [SerializeField] public LcuRune sorceryRuneSlot_03;
        [SerializeField] public LcuRune sorceryRuneSlot_04;
        [SerializeField] public LcuRune sorceryRuneSlot_05;
        [SerializeField] public LcuRune sorceryRuneSlot_06;
        [SerializeField] public LcuRune sorceryRuneSlot_07;
        [SerializeField] public LcuRune sorceryRuneSlot_08;
        [SerializeField] public LcuRune sorceryRuneSlot_09;
        #endregion

        #region Resolve
        [Header("Resolve")]
        [SerializeField] public LcuRune resolveKeyStone_01;
        [SerializeField] public LcuRune resolveKeyStone_02;
        [SerializeField] public LcuRune resolveKeyStone_03;

        [SerializeField] public LcuRune resolveRuneSlot_01;
        [SerializeField] public LcuRune resolveRuneSlot_02;
        [SerializeField] public LcuRune resolveRuneSlot_03;
        [SerializeField] public LcuRune resolveRuneSlot_04;
        [SerializeField] public LcuRune resolveRuneSlot_05;
        [SerializeField] public LcuRune resolveRuneSlot_06;
        [SerializeField] public LcuRune resolveRuneSlot_07;
        [SerializeField] public LcuRune resolveRuneSlot_08;
        [SerializeField] public LcuRune resolveRuneSlot_09;
        #endregion

        #region Inspiration
        [Header("Inspiration")]
        [SerializeField] public LcuRune inspirationKeyStone_01;
        [SerializeField] public LcuRune inspirationKeyStone_02;
        [SerializeField] public LcuRune inspirationKeyStone_03;

        [SerializeField] public LcuRune inspirationRuneSlot_01;
        [SerializeField] public LcuRune inspirationRuneSlot_02;
        [SerializeField] public LcuRune inspirationRuneSlot_03;
        [SerializeField] public LcuRune inspirationRuneSlot_04;
        [SerializeField] public LcuRune inspirationRuneSlot_05;
        [SerializeField] public LcuRune inspirationRuneSlot_06;
        [SerializeField] public LcuRune inspirationRuneSlot_07;
        [SerializeField] public LcuRune inspirationRuneSlot_08;
        [SerializeField] public LcuRune inspirationRuneSlot_09;
        #endregion

        #region Rune Shards
        [Header("Rune Shards")]
        [SerializeField] public LcuRune shardSlot_01 = new LcuRune("5008", RuneTypeEnum.SHARD_SLOT_01);
        [SerializeField] public LcuRune shardSlot_02;
        [SerializeField] public LcuRune shardSlot_03;
        [SerializeField] public LcuRune shardSlot_04 = new LcuRune("5008", RuneTypeEnum.SHARD_SLOT_04);
        [SerializeField] public LcuRune shardSlot_05;
        [SerializeField] public LcuRune shardSlot_06;
        [SerializeField] public LcuRune shardSlot_07 = new LcuRune("5001", RuneTypeEnum.SHARD_SLOT_07);
        [SerializeField] public LcuRune shardSlot_08;
        [SerializeField] public LcuRune shardSlot_09;
        #endregion

        public Dictionary<RuneTypeEnum, string> ExtractIdMapping()
        {
            var lcuIdMapping = new Dictionary<RuneTypeEnum, string>();

            #region Paths
            lcuIdMapping.Add(precision.runeType, precision.id);
            lcuIdMapping.Add(domination.runeType, domination.id);
            //lcuIdMapping.Add(sorcery.runeType, sorcery.id);
            //lcuIdMapping.Add(resolve.runeType, resolve.id);
            //lcuIdMapping.Add(inspiration.runeType, inspiration.id);
            #endregion

            #region Precision
            lcuIdMapping.Add(precisionKeyStone_01.runeType, precisionKeyStone_01.id);
            //lcuIdMapping.Add(precisionKeyStone_02.runeType, precisionKeyStone_02.id);
            //lcuIdMapping.Add(precisionKeyStone_03.runeType, precisionKeyStone_03.id);
            //lcuIdMapping.Add(precisionKeyStone_04.runeType, precisionKeyStone_04.id);

            lcuIdMapping.Add(precisionRuneSlot_01.runeType, precisionRuneSlot_01.id);
            //lcuIdMapping.Add(precisionRuneSlot_02.runeType, precisionRuneSlot_02.id);
            //lcuIdMapping.Add(precisionRuneSlot_03.runeType, precisionRuneSlot_03.id);
            lcuIdMapping.Add(precisionRuneSlot_04.runeType, precisionRuneSlot_04.id);
            //lcuIdMapping.Add(precisionRuneSlot_05.runeType, precisionRuneSlot_05.id);
            //lcuIdMapping.Add(precisionRuneSlot_06.runeType, precisionRuneSlot_06.id);
            lcuIdMapping.Add(precisionRuneSlot_07.runeType, precisionRuneSlot_07.id);
            //lcuIdMapping.Add(precisionRuneSlot_08.runeType, precisionRuneSlot_08.id);
            //lcuIdMapping.Add(precisionRuneSlot_09.runeType, precisionRuneSlot_09.id);
            #endregion

            #region Domination
            //lcuIdMapping.Add(dominationKeyStone_01.runeType, dominationKeyStone_01.id);
            //lcuIdMapping.Add(dominationKeyStone_02.runeType, dominationKeyStone_02.id);
            //lcuIdMapping.Add(dominationKeyStone_03.runeType, dominationKeyStone_03.id);
            //lcuIdMapping.Add(dominationKeyStone_04.runeType, dominationKeyStone_04.id);

            lcuIdMapping.Add(dominationRuneSlot_01.runeType, dominationRuneSlot_01.id);
            //lcuIdMapping.Add(dominationRuneSlot_02.runeType, dominationRuneSlot_02.id);
            //lcuIdMapping.Add(dominationRuneSlot_03.runeType, dominationRuneSlot_03.id);
            lcuIdMapping.Add(dominationRuneSlot_04.runeType, dominationRuneSlot_04.id);
            //lcuIdMapping.Add(dominationRuneSlot_05.runeType, dominationRuneSlot_05.id);
            //lcuIdMapping.Add(dominationRuneSlot_06.runeType, dominationRuneSlot_06.id);
            //lcuIdMapping.Add(dominationRuneSlot_07.runeType, dominationRuneSlot_07.id);
            //lcuIdMapping.Add(dominationRuneSlot_08.runeType, dominationRuneSlot_08.id);
            //lcuIdMapping.Add(dominationRuneSlot_09.runeType, dominationRuneSlot_09.id);
            //lcuIdMapping.Add(dominationRuneSlot_10.runeType, dominationRuneSlot_10.id);
            #endregion

            #region Sorcery
            //lcuIdMapping.Add(sorceryKeyStone_01.runeType, sorceryKeyStone_01.id);
            //lcuIdMapping.Add(sorceryKeyStone_02.runeType, sorceryKeyStone_02.id);
            //lcuIdMapping.Add(sorceryKeyStone_03.runeType, sorceryKeyStone_03.id);
            //
            //lcuIdMapping.Add(sorceryRuneSlot_01.runeType, sorceryRuneSlot_01.id);
            //lcuIdMapping.Add(sorceryRuneSlot_02.runeType, sorceryRuneSlot_02.id);
            //lcuIdMapping.Add(sorceryRuneSlot_03.runeType, sorceryRuneSlot_03.id);
            //lcuIdMapping.Add(sorceryRuneSlot_04.runeType, sorceryRuneSlot_04.id);
            //lcuIdMapping.Add(sorceryRuneSlot_05.runeType, sorceryRuneSlot_05.id);
            //lcuIdMapping.Add(sorceryRuneSlot_06.runeType, sorceryRuneSlot_06.id);
            //lcuIdMapping.Add(sorceryRuneSlot_07.runeType, sorceryRuneSlot_07.id);
            //lcuIdMapping.Add(sorceryRuneSlot_08.runeType, sorceryRuneSlot_08.id);
            //lcuIdMapping.Add(sorceryRuneSlot_09.runeType, sorceryRuneSlot_09.id);
            #endregion

            #region Resolve
            //lcuIdMapping.Add(resolveKeyStone_01.runeType, resolveKeyStone_01.id);
            //lcuIdMapping.Add(resolveKeyStone_02.runeType, resolveKeyStone_02.id);
            //lcuIdMapping.Add(resolveKeyStone_03.runeType, resolveKeyStone_03.id);
            //
            //lcuIdMapping.Add(resolveRuneSlot_01.runeType, resolveRuneSlot_01.id);
            //lcuIdMapping.Add(resolveRuneSlot_02.runeType, resolveRuneSlot_02.id);
            //lcuIdMapping.Add(resolveRuneSlot_03.runeType, resolveRuneSlot_03.id);
            //lcuIdMapping.Add(resolveRuneSlot_04.runeType, resolveRuneSlot_04.id);
            //lcuIdMapping.Add(resolveRuneSlot_05.runeType, resolveRuneSlot_05.id);
            //lcuIdMapping.Add(resolveRuneSlot_06.runeType, resolveRuneSlot_06.id);
            //lcuIdMapping.Add(resolveRuneSlot_07.runeType, resolveRuneSlot_07.id);
            //lcuIdMapping.Add(resolveRuneSlot_08.runeType, resolveRuneSlot_08.id);
            //lcuIdMapping.Add(resolveRuneSlot_09.runeType, resolveRuneSlot_09.id);
            #endregion

            #region Inspiration
            //lcuIdMapping.Add(inspirationKeyStone_01.runeType, inspirationKeyStone_01.id);
            //lcuIdMapping.Add(inspirationKeyStone_02.runeType, inspirationKeyStone_02.id);
            //lcuIdMapping.Add(inspirationKeyStone_03.runeType, inspirationKeyStone_03.id);
            //
            //lcuIdMapping.Add(inspirationRuneSlot_01.runeType, inspirationRuneSlot_01.id);
            //lcuIdMapping.Add(inspirationRuneSlot_02.runeType, inspirationRuneSlot_02.id);
            //lcuIdMapping.Add(inspirationRuneSlot_03.runeType, inspirationRuneSlot_03.id);
            //lcuIdMapping.Add(inspirationRuneSlot_04.runeType, inspirationRuneSlot_04.id);
            //lcuIdMapping.Add(inspirationRuneSlot_05.runeType, inspirationRuneSlot_05.id);
            //lcuIdMapping.Add(inspirationRuneSlot_06.runeType, inspirationRuneSlot_06.id);
            //lcuIdMapping.Add(inspirationRuneSlot_07.runeType, inspirationRuneSlot_07.id);
            //lcuIdMapping.Add(inspirationRuneSlot_08.runeType, inspirationRuneSlot_08.id);
            //lcuIdMapping.Add(inspirationRuneSlot_09.runeType, inspirationRuneSlot_09.id);
            #endregion

            #region Shards
            lcuIdMapping.Add(shardSlot_01.runeType, shardSlot_01.id);
            //lcuIdMapping.Add(shardSlot_02.runeType, shardSlot_02.id);
            //lcuIdMapping.Add(shardSlot_03.runeType, shardSlot_03.id);
            lcuIdMapping.Add(shardSlot_04.runeType, shardSlot_04.id);
            //lcuIdMapping.Add(shardSlot_05.runeType, shardSlot_05.id);
            //lcuIdMapping.Add(shardSlot_06.runeType, shardSlot_06.id);
            lcuIdMapping.Add(shardSlot_07.runeType, shardSlot_07.id);
            //lcuIdMapping.Add(shardSlot_08.runeType, shardSlot_08.id);
            //lcuIdMapping.Add(shardSlot_09.runeType, shardSlot_09.id);
            #endregion

            return lcuIdMapping;
        }
    }
}