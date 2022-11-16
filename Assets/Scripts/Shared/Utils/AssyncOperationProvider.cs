using System.Collections;
using UnityEngine;

namespace LoLRunes.Shared.Utils
{
    public class AssyncOperationProvider : MonoBehaviour
    {
        #region Static
        public static AssyncOperationProvider instance { get; private set; }
        #endregion

        private void Awake()
        {
            if (instance)
            {
                Destroy(this);
                return;
            }

            instance = this;
        }

        public Coroutine RunAsync(IEnumerator enumerator)
        {
            return StartCoroutine(enumerator);
        }
    }
}