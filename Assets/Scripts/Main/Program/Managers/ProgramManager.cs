using LoLRunes.Domain.WindowInteraction.Services;
using LoLRunes.Enumerators;
using LoLRunes.ScriptableObjects;
using System.Collections;
using UnityEngine;

namespace LoLRunes.Program.Managers
{
    public class ProgramManager : MonoBehaviour
    {
        #region Static
        public static ProgramManager instance { get; private set; }
        #endregion

        [SerializeField] private ResolutionRunePositionConfig _resolutionRunePositionConfig_01;

        public RuneMenuEnum runeMenu { get; set; }
        public ResolutionRunePositionConfig activeResolutionRunePositionConfig { get; private set; }

        private void Awake()
        {
            if(instance)
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

            RunePagePositionService.instance.MapPositionConfig(activeResolutionRunePositionConfig);
        }

        public Coroutine RunAsync(IEnumerator enumerator)
        {
            return StartCoroutine(enumerator);
        }
    }
}