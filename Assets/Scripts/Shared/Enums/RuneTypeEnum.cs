using LoLRunes.Shared.CustumAttributes;

namespace LoLRunes.Shared.Enums
{
    public enum RuneTypeEnum
    {
        #region Precision
        [RuneGroup(RuneGroupEnum.PATH)]
        [RunePositionReference(RunePositionReferenceEnum.PATH_01)]
        PRECISION_PATH = 8000,


        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_01_01)]
        PRECISION_KEYSTONE_01 = 8005,

        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_01_02)]
        PRECISION_KEYSTONE_02 = 8008,

        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_01_03)]
        PRECISION_KEYSTONE_03 = 8021,

        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_01_04)]
        PRECISION_KEYSTONE_04 = 8010,


        [RuneGroup(RuneGroupEnum.RUNE_01)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_01_01)]
        PRECISION_RUNE_SLOT_01 = 9101,

        [RuneGroup(RuneGroupEnum.RUNE_01)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_01_02)]
        PRECISION_RUNE_SLOT_02,

        [RuneGroup(RuneGroupEnum.RUNE_01)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_01_03)]
        PRECISION_RUNE_SLOT_03,

        [RuneGroup(RuneGroupEnum.RUNE_02)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_02_01)]
        PRECISION_RUNE_SLOT_04 = 9104,

        [RuneGroup(RuneGroupEnum.RUNE_02)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_02_02)]
        PRECISION_RUNE_SLOT_05,

        [RuneGroup(RuneGroupEnum.RUNE_02)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_02_03)]
        PRECISION_RUNE_SLOT_06,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_03_01)]
        PRECISION_RUNE_SLOT_07 = 8014,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_03_02)]
        PRECISION_RUNE_SLOT_08,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_03_03)]
        PRECISION_RUNE_SLOT_09,
        #endregion

        #region Domination
        [RuneGroup(RuneGroupEnum.PATH)]
        [RunePositionReference(RunePositionReferenceEnum.PATH_02)]
        DOMINATION_PATH = 8100,


        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_01_01)]
        DOMINATION_KEYSTONE_01 = 8112,

        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_01_02)]
        DOMINATION_KEYSTONE_02,

        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_01_03)]
        DOMINATION_KEYSTONE_03,

        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_01_04)]
        DOMINATION_KEYSTONE_04,


        [RuneGroup(RuneGroupEnum.RUNE_01)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_01_01)]
        DOMINATION_RUNE_SLOT_01 = 8126,

        [RuneGroup(RuneGroupEnum.RUNE_01)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_01_02)]
        DOMINATION_RUNE_SLOT_02,

        [RuneGroup(RuneGroupEnum.RUNE_01)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_01_03)]
        DOMINATION_RUNE_SLOT_03,

        [RuneGroup(RuneGroupEnum.RUNE_02)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_02_01)]
        DOMINATION_RUNE_SLOT_04 = 8136,

        [RuneGroup(RuneGroupEnum.RUNE_02)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_02_02)]
        DOMINATION_RUNE_SLOT_05,

        [RuneGroup(RuneGroupEnum.RUNE_02)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_02_03)]
        DOMINATION_RUNE_SLOT_06,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_04_01)]
        DOMINATION_RUNE_SLOT_07 = 8135,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_04_02)]
        DOMINATION_RUNE_SLOT_08,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_04_03)]
        DOMINATION_RUNE_SLOT_09,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_04_04)]
        DOMINATION_RUNE_SLOT_10,
        #endregion

        #region Sorcery
        [RuneGroup(RuneGroupEnum.PATH)]
        [RunePositionReference(RunePositionReferenceEnum.PATH_03)]
        SORCERY_PATH,


        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_02_01)]
        SORCERY_KEYSTONE_01,

        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_02_02)]
        SORCERY_KEYSTONE_02,

        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_02_03)]
        SORCERY_KEYSTONE_03,


        [RuneGroup(RuneGroupEnum.RUNE_01)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_01_01)]
        SORCERY_RUNE_SLOT_01,

        [RuneGroup(RuneGroupEnum.RUNE_01)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_01_02)]
        SORCERY_RUNE_SLOT_02,

        [RuneGroup(RuneGroupEnum.RUNE_01)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_01_03)]
        SORCERY_RUNE_SLOT_03,

        [RuneGroup(RuneGroupEnum.RUNE_02)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_02_01)]
        SORCERY_RUNE_SLOT_04,

        [RuneGroup(RuneGroupEnum.RUNE_02)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_02_02)]
        SORCERY_RUNE_SLOT_05,

        [RuneGroup(RuneGroupEnum.RUNE_02)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_02_03)]
        SORCERY_RUNE_SLOT_06,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_03_01)]
        SORCERY_RUNE_SLOT_07,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_03_02)]
        SORCERY_RUNE_SLOT_08,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_03_03)]
        SORCERY_RUNE_SLOT_09,
        #endregion

        #region Resolve
        [RuneGroup(RuneGroupEnum.PATH)]
        [RunePositionReference(RunePositionReferenceEnum.PATH_04)]
        RESOLVE_PATH,


        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_02_01)]
        RESOLVE_KEYSTONE_01,

        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_02_02)]
        RESOLVE_KEYSTONE_02,

        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_02_03)]
        RESOLVE_KEYSTONE_03,


        [RuneGroup(RuneGroupEnum.RUNE_01)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_01_01)]
        RESOLVE_RUNE_SLOT_01,

        [RuneGroup(RuneGroupEnum.RUNE_01)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_01_02)]
        RESOLVE_RUNE_SLOT_02,

        [RuneGroup(RuneGroupEnum.RUNE_01)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_01_03)]
        RESOLVE_RUNE_SLOT_03,

        [RuneGroup(RuneGroupEnum.RUNE_02)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_02_01)]
        RESOLVE_RUNE_SLOT_04,

        [RuneGroup(RuneGroupEnum.RUNE_02)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_02_02)]
        RESOLVE_RUNE_SLOT_05,

        [RuneGroup(RuneGroupEnum.RUNE_02)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_02_03)]
        RESOLVE_RUNE_SLOT_06,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_03_01)]
        RESOLVE_RUNE_SLOT_07,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_03_02)]
        RESOLVE_RUNE_SLOT_08,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_03_03)]
        RESOLVE_RUNE_SLOT_09,
        #endregion

        #region Inspiration
        [RuneGroup(RuneGroupEnum.PATH)]
        [RunePositionReference(RunePositionReferenceEnum.PATH_05)]
        INPIRATION_PATH,


        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_02_01)]
        INPIRATION_KEYSTONE_01,

        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_02_02)]
        INPIRATION_KEYSTONE_02,

        [RuneGroup(RuneGroupEnum.KEYSTONE)]
        [RunePositionReference(RunePositionReferenceEnum.KEYSTONE_02_03)]
        INPIRATION_KEYSTONE_03,


        [RuneGroup(RuneGroupEnum.RUNE_01)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_01_01)]
        INPIRATION_RUNE_SLOT_01,

        [RuneGroup(RuneGroupEnum.RUNE_01)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_01_02)]
        INPIRATION_RUNE_SLOT_02,

        [RuneGroup(RuneGroupEnum.RUNE_01)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_01_03)]
        INPIRATION_RUNE_SLOT_03,

        [RuneGroup(RuneGroupEnum.RUNE_02)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_02_01)]
        INPIRATION_RUNE_SLOT_04,

        [RuneGroup(RuneGroupEnum.RUNE_02)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_02_02)]
        INPIRATION_RUNE_SLOT_05,

        [RuneGroup(RuneGroupEnum.RUNE_02)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_02_03)]
        INPIRATION_RUNE_SLOT_06,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_03_01)]
        INPIRATION_RUNE_SLOT_07,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_03_02)]
        INPIRATION_RUNE_SLOT_08,

        [RuneGroup(RuneGroupEnum.RUNE_03)]
        [RunePositionReference(RunePositionReferenceEnum.RUNE_SLOT_03_03)]
        INPIRATION_RUNE_SLOT_09,
        #endregion

        #region Rune Shards
        [RuneGroup(RuneGroupEnum.SHARDS_ATTACK)]
        [RunePositionReference(RunePositionReferenceEnum.SHARDS_SLOT_01_01)]
        SHARD_SLOT_01 = 5008,

        [RuneGroup(RuneGroupEnum.SHARDS_ATTACK)]
        [RunePositionReference(RunePositionReferenceEnum.SHARDS_SLOT_01_02)]
        SHARD_SLOT_02 = 5005,

        [RuneGroup(RuneGroupEnum.SHARDS_ATTACK)]
        [RunePositionReference(RunePositionReferenceEnum.SHARDS_SLOT_01_03)]
        SHARD_SLOT_03 = 5007,

        [RuneGroup(RuneGroupEnum.SHARDS_FLEX)]
        [RunePositionReference(RunePositionReferenceEnum.SHARDS_SLOT_02_01)]
        SHARD_SLOT_04 = 5008,

        [RuneGroup(RuneGroupEnum.SHARDS_FLEX)]
        [RunePositionReference(RunePositionReferenceEnum.SHARDS_SLOT_02_02)]
        SHARD_SLOT_05 = 5002,

        [RuneGroup(RuneGroupEnum.SHARDS_FLEX)]
        [RunePositionReference(RunePositionReferenceEnum.SHARDS_SLOT_02_03)]
        SHARD_SLOT_06 = 5003,

        [RuneGroup(RuneGroupEnum.SHARDS_DEFENCE)]
        [RunePositionReference(RunePositionReferenceEnum.SHARDS_SLOT_03_01)]
        SHARD_SLOT_07 = 5001,

        [RuneGroup(RuneGroupEnum.SHARDS_DEFENCE)]
        [RunePositionReference(RunePositionReferenceEnum.SHARDS_SLOT_03_02)]
        SHARD_SLOT_08 = 5002,

        [RuneGroup(RuneGroupEnum.SHARDS_DEFENCE)]
        [RunePositionReference(RunePositionReferenceEnum.SHARDS_SLOT_03_03)]
        SHARD_SLOT_09 = 5003,
        #endregion
    }
}
