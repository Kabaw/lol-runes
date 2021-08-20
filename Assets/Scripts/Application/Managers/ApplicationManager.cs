using LoLRunes.ScriptableObjects;
using UnityEngine;

namespace LoLRunes.Application.Manager
{
    public class ApplicationManager : MonoBehaviour
    {
        [SerializeField] private ResolutionRunePositionConfig _resolutionRunePositionConfig;

        public ResolutionRunePositionConfig resolutionRunePositionConfig => _resolutionRunePositionConfig;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}