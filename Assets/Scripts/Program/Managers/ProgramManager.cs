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
        //[SerializeField] private ResolutionRunePositionConfig _resolutionRunePositionConfig_02;
        //[SerializeField] private ResolutionRunePositionConfig _resolutionRunePositionConfig_03;

        public RuneMenuEnum runeMenu { get; private set; }
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
            runeMenu = RuneMenuEnum.RUNE_SCREEN;
            activeResolutionRunePositionConfig = _resolutionRunePositionConfig_01;
        }

        public Coroutine RunAsync(IEnumerator enumerator)
        {
            return StartCoroutine(enumerator);
        }
    }
}