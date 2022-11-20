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
        [SerializeField] private LcuRune precision = new LcuRune("8000", RuneTypeEnum.PRECISION_PATH);
        [SerializeField] private LcuRune domination = new LcuRune("8100", RuneTypeEnum.PRECISION_PATH);
        [SerializeField] private LcuRune sorcery;
        [SerializeField] private LcuRune resolve;
        [SerializeField] private LcuRune inspiration;
        #endregion

        #region Precision
        [Header("Precision")]
        [SerializeField] private LcuRune precisionKeyStone_01 = new LcuRune("8005", RuneTypeEnum.PRECISION_PATH);
        [SerializeField] private LcuRune precisionKeyStone_02;
        [SerializeField] private LcuRune precisionKeyStone_03;
        [SerializeField] private LcuRune precisionKeyStone_04;

        [SerializeField] private LcuRune precisionRuneSlot_01 = new LcuRune("9101", RuneTypeEnum.PRECISION_PATH);
        [SerializeField] private LcuRune precisionRuneSlot_02;
        [SerializeField] private LcuRune precisionRuneSlot_03;
        [SerializeField] private LcuRune precisionRuneSlot_04 = new LcuRune("9104", RuneTypeEnum.PRECISION_PATH);
        [SerializeField] private LcuRune precisionRuneSlot_05;
        [SerializeField] private LcuRune precisionRuneSlot_06;
        [SerializeField] private LcuRune precisionRuneSlot_07 = new LcuRune("8014", RuneTypeEnum.PRECISION_PATH);
        [SerializeField] private LcuRune precisionRuneSlot_08;
        [SerializeField] private LcuRune precisionRuneSlot_09;
        #endregion

        #region Domination
        [Header("Domination")]
        [SerializeField] private LcuRune dominationKeyStone_01 = new LcuRune("8112", RuneTypeEnum.PRECISION_PATH);
        [SerializeField] private LcuRune dominationKeyStone_02;
        [SerializeField] private LcuRune dominationKeyStone_03;
        [SerializeField] private LcuRune dominationKeyStone_04;

        [SerializeField] private LcuRune dominationRuneSlot_01 = new LcuRune("8126", RuneTypeEnum.PRECISION_PATH);
        [SerializeField] private LcuRune dominationRuneSlot_02;
        [SerializeField] private LcuRune dominationRuneSlot_03;
        [SerializeField] private LcuRune dominationRuneSlot_04 = new LcuRune("8136", RuneTypeEnum.PRECISION_PATH);
        [SerializeField] private LcuRune dominationRuneSlot_05;
        [SerializeField] private LcuRune dominationRuneSlot_06;
        [SerializeField] private LcuRune dominationRuneSlot_07 = new LcuRune("8135", RuneTypeEnum.PRECISION_PATH);
        [SerializeField] private LcuRune dominationRuneSlot_08;
        [SerializeField] private LcuRune dominationRuneSlot_09;
        [SerializeField] private LcuRune dominationRuneSlot_10;
        #endregion

        #region Sorcery
        [Header("Sorcery")]
        [SerializeField] private LcuRune sorceryKeyStone_01;
        [SerializeField] private LcuRune sorceryKeyStone_02;
        [SerializeField] private LcuRune sorceryKeyStone_03;

        [SerializeField] private LcuRune sorceryRuneSlot_01;
        [SerializeField] private LcuRune sorceryRuneSlot_02;
        [SerializeField] private LcuRune sorceryRuneSlot_03;
        [SerializeField] private LcuRune sorceryRuneSlot_04;
        [SerializeField] private LcuRune sorceryRuneSlot_05;
        [SerializeField] private LcuRune sorceryRuneSlot_06;
        [SerializeField] private LcuRune sorceryRuneSlot_07;
        [SerializeField] private LcuRune sorceryRuneSlot_08;
        [SerializeField] private LcuRune sorceryRuneSlot_09;
        #endregion

        #region Resolve
        [Header("Resolve")]
        [SerializeField] private LcuRune resolveKeyStone_01;
        [SerializeField] private LcuRune resolveKeyStone_02;
        [SerializeField] private LcuRune resolveKeyStone_03;

        [SerializeField] private LcuRune resolveRuneSlot_01;
        [SerializeField] private LcuRune resolveRuneSlot_02;
        [SerializeField] private LcuRune resolveRuneSlot_03;
        [SerializeField] private LcuRune resolveRuneSlot_04;
        [SerializeField] private LcuRune resolveRuneSlot_05;
        [SerializeField] private LcuRune resolveRuneSlot_06;
        [SerializeField] private LcuRune resolveRuneSlot_07;
        [SerializeField] private LcuRune resolveRuneSlot_08;
        [SerializeField] private LcuRune resolveRuneSlot_09;
        #endregion

        #region Inspiration
        [Header("Inspiration")]
        [SerializeField] private LcuRune inspirationKeyStone_01;
        [SerializeField] private LcuRune inspirationKeyStone_02;
        [SerializeField] private LcuRune inspirationKeyStone_03;

        [SerializeField] private LcuRune inspirationRuneSlot_01;
        [SerializeField] private LcuRune inspirationRuneSlot_02;
        [SerializeField] private LcuRune inspirationRuneSlot_03;
        [SerializeField] private LcuRune inspirationRuneSlot_04;
        [SerializeField] private LcuRune inspirationRuneSlot_05;
        [SerializeField] private LcuRune inspirationRuneSlot_06;
        [SerializeField] private LcuRune inspirationRuneSlot_07;
        [SerializeField] private LcuRune inspirationRuneSlot_08;
        [SerializeField] private LcuRune inspirationRuneSlot_09;
        #endregion

        #region Rune Shards
        [Header("Rune Shards")]
        [SerializeField] private LcuRune shardSlot_01 = new LcuRune("5008", RuneTypeEnum.PRECISION_PATH);
        [SerializeField] private LcuRune shardSlot_02;
        [SerializeField] private LcuRune shardSlot_03;
        [SerializeField] private LcuRune shardSlot_04 = new LcuRune("5008", RuneTypeEnum.PRECISION_PATH);
        [SerializeField] private LcuRune shardSlot_05;
        [SerializeField] private LcuRune shardSlot_06;
        [SerializeField] private LcuRune shardSlot_07 = new LcuRune("5001", RuneTypeEnum.PRECISION_PATH);
        [SerializeField] private LcuRune shardSlot_08;
        [SerializeField] private LcuRune shardSlot_09;
        #endregion

        private Dictionary<RuneTypeEnum, string> _lcuIdMapping;

        public Dictionary<RuneTypeEnum, string> lcuIdMapping
        {
            get
            {
                if (_lcuIdMapping is null)
                {                
                    _lcuIdMapping = new Dictionary<RuneTypeEnum, string>();
                    PopulateIdMapping();
                }

                return _lcuIdMapping;
            }
        }

        private void PopulateIdMapping()
        {
            #region Paths
            _lcuIdMapping.Add(precision.runeType, precision.id);
            _lcuIdMapping.Add(domination.runeType, domination.id);
            _lcuIdMapping.Add(sorcery.runeType, sorcery.id);
            _lcuIdMapping.Add(resolve.runeType, resolve.id);
            _lcuIdMapping.Add(inspiration.runeType, inspiration.id);
            #endregion

            #region Precision
            _lcuIdMapping.Add(precisionKeyStone_01.runeType, precisionKeyStone_01.id);
            _lcuIdMapping.Add(precisionKeyStone_02.runeType, precisionKeyStone_02.id);
            _lcuIdMapping.Add(precisionKeyStone_03.runeType, precisionKeyStone_03.id);
            _lcuIdMapping.Add(precisionKeyStone_04.runeType, precisionKeyStone_04.id);

            _lcuIdMapping.Add(precisionRuneSlot_01.runeType, precisionRuneSlot_01.id);
            _lcuIdMapping.Add(precisionRuneSlot_02.runeType, precisionRuneSlot_02.id);
            _lcuIdMapping.Add(precisionRuneSlot_03.runeType, precisionRuneSlot_03.id);
            _lcuIdMapping.Add(precisionRuneSlot_04.runeType, precisionRuneSlot_04.id);
            _lcuIdMapping.Add(precisionRuneSlot_05.runeType, precisionRuneSlot_05.id);
            _lcuIdMapping.Add(precisionRuneSlot_06.runeType, precisionRuneSlot_06.id);
            _lcuIdMapping.Add(precisionRuneSlot_07.runeType, precisionRuneSlot_07.id);
            _lcuIdMapping.Add(precisionRuneSlot_08.runeType, precisionRuneSlot_08.id);
            _lcuIdMapping.Add(precisionRuneSlot_09.runeType, precisionRuneSlot_09.id);
            #endregion

            #region Domination
            _lcuIdMapping.Add(dominationKeyStone_01.runeType, dominationKeyStone_01.id);
            _lcuIdMapping.Add(dominationKeyStone_02.runeType, dominationKeyStone_02.id);
            _lcuIdMapping.Add(dominationKeyStone_03.runeType, dominationKeyStone_03.id);
            _lcuIdMapping.Add(dominationKeyStone_04.runeType, dominationKeyStone_04.id);

            _lcuIdMapping.Add(dominationRuneSlot_01.runeType, dominationRuneSlot_01.id);
            _lcuIdMapping.Add(dominationRuneSlot_02.runeType, dominationRuneSlot_02.id);
            _lcuIdMapping.Add(dominationRuneSlot_03.runeType, dominationRuneSlot_03.id);
            _lcuIdMapping.Add(dominationRuneSlot_04.runeType, dominationRuneSlot_04.id);
            _lcuIdMapping.Add(dominationRuneSlot_05.runeType, dominationRuneSlot_05.id);
            _lcuIdMapping.Add(dominationRuneSlot_06.runeType, dominationRuneSlot_06.id);
            _lcuIdMapping.Add(dominationRuneSlot_07.runeType, dominationRuneSlot_07.id);
            _lcuIdMapping.Add(dominationRuneSlot_08.runeType, dominationRuneSlot_08.id);
            _lcuIdMapping.Add(dominationRuneSlot_09.runeType, dominationRuneSlot_09.id);
            _lcuIdMapping.Add(dominationRuneSlot_10.runeType, dominationRuneSlot_10.id);
            #endregion

            #region Sorcery
            _lcuIdMapping.Add(sorceryKeyStone_01.runeType, sorceryKeyStone_01.id);
            _lcuIdMapping.Add(sorceryKeyStone_02.runeType, sorceryKeyStone_02.id);
            _lcuIdMapping.Add(sorceryKeyStone_03.runeType, sorceryKeyStone_03.id);

            _lcuIdMapping.Add(sorceryRuneSlot_01.runeType, sorceryRuneSlot_01.id);
            _lcuIdMapping.Add(sorceryRuneSlot_02.runeType, sorceryRuneSlot_02.id);
            _lcuIdMapping.Add(sorceryRuneSlot_03.runeType, sorceryRuneSlot_03.id);
            _lcuIdMapping.Add(sorceryRuneSlot_04.runeType, sorceryRuneSlot_04.id);
            _lcuIdMapping.Add(sorceryRuneSlot_05.runeType, sorceryRuneSlot_05.id);
            _lcuIdMapping.Add(sorceryRuneSlot_06.runeType, sorceryRuneSlot_06.id);
            _lcuIdMapping.Add(sorceryRuneSlot_07.runeType, sorceryRuneSlot_07.id);
            _lcuIdMapping.Add(sorceryRuneSlot_08.runeType, sorceryRuneSlot_08.id);
            _lcuIdMapping.Add(sorceryRuneSlot_09.runeType, sorceryRuneSlot_09.id);
            #endregion

            #region Resolve
            _lcuIdMapping.Add(resolveKeyStone_01.runeType, resolveKeyStone_01.id);
            _lcuIdMapping.Add(resolveKeyStone_02.runeType, resolveKeyStone_02.id);
            _lcuIdMapping.Add(resolveKeyStone_03.runeType, resolveKeyStone_03.id);

            _lcuIdMapping.Add(resolveRuneSlot_01.runeType, resolveRuneSlot_01.id);
            _lcuIdMapping.Add(resolveRuneSlot_02.runeType, resolveRuneSlot_02.id);
            _lcuIdMapping.Add(resolveRuneSlot_03.runeType, resolveRuneSlot_03.id);
            _lcuIdMapping.Add(resolveRuneSlot_04.runeType, resolveRuneSlot_04.id);
            _lcuIdMapping.Add(resolveRuneSlot_05.runeType, resolveRuneSlot_05.id);
            _lcuIdMapping.Add(resolveRuneSlot_06.runeType, resolveRuneSlot_06.id);
            _lcuIdMapping.Add(resolveRuneSlot_07.runeType, resolveRuneSlot_07.id);
            _lcuIdMapping.Add(resolveRuneSlot_08.runeType, resolveRuneSlot_08.id);
            _lcuIdMapping.Add(resolveRuneSlot_09.runeType, resolveRuneSlot_09.id);
            #endregion

            #region Inspiration
            _lcuIdMapping.Add(inspirationKeyStone_01.runeType, inspirationKeyStone_01.id);
            _lcuIdMapping.Add(inspirationKeyStone_02.runeType, inspirationKeyStone_02.id);
            _lcuIdMapping.Add(inspirationKeyStone_03.runeType, inspirationKeyStone_03.id);

            _lcuIdMapping.Add(inspirationRuneSlot_01.runeType, inspirationRuneSlot_01.id);
            _lcuIdMapping.Add(inspirationRuneSlot_02.runeType, inspirationRuneSlot_02.id);
            _lcuIdMapping.Add(inspirationRuneSlot_03.runeType, inspirationRuneSlot_03.id);
            _lcuIdMapping.Add(inspirationRuneSlot_04.runeType, inspirationRuneSlot_04.id);
            _lcuIdMapping.Add(inspirationRuneSlot_05.runeType, inspirationRuneSlot_05.id);
            _lcuIdMapping.Add(inspirationRuneSlot_06.runeType, inspirationRuneSlot_06.id);
            _lcuIdMapping.Add(inspirationRuneSlot_07.runeType, inspirationRuneSlot_07.id);
            _lcuIdMapping.Add(inspirationRuneSlot_08.runeType, inspirationRuneSlot_08.id);
            _lcuIdMapping.Add(inspirationRuneSlot_09.runeType, inspirationRuneSlot_09.id);
            #endregion

            #region Shards
            _lcuIdMapping.Add(shardSlot_01.runeType, shardSlot_01.id);
            _lcuIdMapping.Add(shardSlot_02.runeType, shardSlot_02.id);
            _lcuIdMapping.Add(shardSlot_03.runeType, shardSlot_03.id);
            _lcuIdMapping.Add(shardSlot_04.runeType, shardSlot_04.id);
            _lcuIdMapping.Add(shardSlot_05.runeType, shardSlot_05.id);
            _lcuIdMapping.Add(shardSlot_06.runeType, shardSlot_06.id);
            _lcuIdMapping.Add(shardSlot_07.runeType, shardSlot_07.id);
            _lcuIdMapping.Add(shardSlot_08.runeType, shardSlot_08.id);
            _lcuIdMapping.Add(shardSlot_09.runeType, shardSlot_09.id);
            #endregion
        }
    }
}