using LoLRunes.Shared.Enums;
using LoLRunes.Shared.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace LoLRunes.Infra
{
    public class InspectorDataProvider : MonoBehaviour, IInspectorDataProvider
    {
        #region Static
        public static InspectorDataProvider instance { get; private set; }
        #endregion

        [SerializeField] string _lcuEnginePath;
        [SerializeField] string _lcuEngineFileName;
        [SerializeField] private LcuRuneIdConfig lcuRuneIdConfig;
        [SerializeField] private ResolutionRunePositionConfig resolutionRunePositionConfig_01;

        public string lcuEnginePath => _lcuEnginePath;
        public string lcuEngineFileName => _lcuEngineFileName;
        public RuneMenuEnum runeMenu { get; set; }
        public Dictionary<RuneTypeEnum, string> lcuIdMapping { get; private set; }
        public ResolutionRunePositionConfig activeResolutionRunePositionConfig { get; private set; }

        private void Awake()
        {
            if (instance)
            {
                Destroy(this);
                return;
            }

            instance = this;
        }

        private void Start()
        {
            runeMenu = RuneMenuEnum.CHAMPION_SELECTION_SCREEN;
            activeResolutionRunePositionConfig = resolutionRunePositionConfig_01;

            lcuIdMapping = lcuRuneIdConfig.ExtractIdMapping();
        }
    }
}