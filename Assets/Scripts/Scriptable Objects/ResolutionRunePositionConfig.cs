using System.Drawing;
using UnityEngine;
using LoLRunes.Enumerators;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using LoLRunes.Enumerators.Extensions;

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

        public Point GetRuneRelativePosition(RunePositionReferenceEnum runePositionReferenceEnum)
        {
            return GetRelativePositions()[runePositionReferenceEnum];
        }

        private Dictionary<RunePositionReferenceEnum, Point> GetRelativePositions()
        {
            Dictionary<RunePositionReferenceEnum, Point> relativePositionDict = new Dictionary<RunePositionReferenceEnum, Point>();

            string[] positions = relativePositions.Split(new char[] { ';' });
            List<RuneTypeEnum> runeTypeValues = (Enum.GetValues(typeof(RuneTypeEnum)) as RuneTypeEnum[]).ToList();

            for (int count = 0; count < runeTypeValues.Count; count++)
            {
                string[] textPoint = positions[0].Split(new char[] { ' ' });
                Point point = new Point(int.Parse(textPoint[0]), int.Parse(textPoint[1]));

                relativePositionDict.Add(runeTypeValues[count].GetPositionReference(), point);
            }

            return relativePositionDict;
        }
    }
}