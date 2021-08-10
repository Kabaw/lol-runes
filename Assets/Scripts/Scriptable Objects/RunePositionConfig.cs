using UnityEngine;

namespace LoLRunes.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ResolutionRunePositionConfig_xx", menuName = "Scriptable Objects/Positioning/ResolutionRunePositionConfig")]
    public class ResolutionRunePositionConfig : ScriptableObject
    {
        [SerializeField] private int resolutionX;
        [SerializeField] private int resolutionY;
        [SerializeField] private int windowX;
        [SerializeField] private int windowY;
        [SerializeField] private string positions;

        public int ResolutionX => resolutionX;
        public int ResolutionY => resolutionY;
        public int WindowX => windowX;
        public int WindowY => windowY;
        public string Positions => positions;
    }
}