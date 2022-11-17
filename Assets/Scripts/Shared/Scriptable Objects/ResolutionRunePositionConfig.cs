using LoLRunes.Shared.Dtos;
using System.Drawing;
using UnityEngine;

namespace LoLRunes.Shared.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ResolutionRunePositionConfig_xx", menuName = "Scriptable Objects/Positioning/ResolutionRunePositionConfig")]
    public class ResolutionRunePositionConfig : ScriptableObject
    {
        [SerializeField] private int resolutionX;
        [SerializeField] private int resolutionY;
        [SerializeField] private Vector2 championScreenOffSet;
        [SerializeField] private RunePagePositions runePagePositions;

        public int ResolutionX => resolutionX;
        public int ResolutionY => resolutionY;
        public RunePagePositions RunePagePositions => runePagePositions;

        public Point ChampionScreenOffSet
        {
            get { return new Point( (int)championScreenOffSet.x, (int)championScreenOffSet.y); }
        }
    }
}