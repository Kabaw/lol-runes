using UnityEngine;

namespace LoLRunes.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ResolutionRunePositionConfig_xx", menuName = "Scriptable Objects/Positioning/ResolutionRunePositionConfig")]
    public class ResolutionRunePositionConfig : ScriptableObject
    {
        [SerializeField] private int resolutionX;
        [SerializeField] private int resolutionY;
        [SerializeField] private string relativePositions;
        [SerializeField] private Vector2 championScreenOffSet;

        public int ResolutionX => resolutionX;
        public int ResolutionY => resolutionY;
        public string RelativePositions => relativePositions;
        public Vector2 ChampionScreenOffSet => championScreenOffSet;
    }
}