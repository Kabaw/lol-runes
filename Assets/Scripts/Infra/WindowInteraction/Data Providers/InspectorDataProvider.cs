using LoLRunes.Shared.Enums;
using LoLRunes.Shared.ScriptableObjects;
using UnityEngine;

namespace LoLRunes.Infra
{
    public class InspectorDataProvider : MonoBehaviour, IInspectorDataProvider
    {
        #region Static
        public static InspectorDataProvider instance { get; private set; }
        #endregion

        [SerializeField] string _lcuEnginePath;
        [SerializeField] private LcuRuneIdConfig lcuRuneIdConfig_01;
        [SerializeField] private ResolutionRunePositionConfig resolutionRunePositionConfig_01;

        public string lcuEnginePath => _lcuEnginePath;
        public RuneMenuEnum runeMenu { get; set; }
        public LcuRuneIdConfig lcuRuneIdConfig { get; private set; }
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
            lcuRuneIdConfig = lcuRuneIdConfig_01;
        }
    }
}