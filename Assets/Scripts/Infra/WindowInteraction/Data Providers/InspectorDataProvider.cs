﻿using LoLRunes.Domain.ScriptableObjects;
using LoLRunes.Shared.Enums;
using UnityEngine;

namespace LoLRunes.Infra
{
    public class InspectorDataProvider : MonoBehaviour, IInspectorDataProvider
    {
        #region Static
        public static InspectorDataProvider instance { get; private set; }
        #endregion

        [SerializeField] private ResolutionRunePositionConfig _resolutionRunePositionConfig_01;

        public RuneMenuEnum runeMenu { get; set; }
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
            activeResolutionRunePositionConfig = _resolutionRunePositionConfig_01;
        }
    }
}