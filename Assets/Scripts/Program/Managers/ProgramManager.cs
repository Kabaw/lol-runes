using LoLRunes.ScriptableObjects;
using UnityEngine;

namespace LoLRunes.Program.Managers
{
    public class ProgramManager : MonoBehaviour
    {
        #region Static
        public static ProgramManager instance { get; private set; }
        #endregion

        [SerializeField] private ResolutionRunePositionConfig _resolutionRunePositionConfig;

        public ResolutionRunePositionConfig resolutionRunePositionConfig => _resolutionRunePositionConfig;

        private void Awake()
        {
            if(instance)
            {
                Destroy(this);
                return;
            }

            instance = this;
        }
    }
}