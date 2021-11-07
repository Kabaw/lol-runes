using System;
using System.Drawing;
using System.Collections.Generic;
using LoLRunes.Domain.Commands;
using LoLRunes.Domain.Models;
using LoLRunes.Enumerators;
using LoLRunes.ScriptableObjects;
using LoLRunes.Program.Managers;
using System.Linq;
using LoLRunes.Utils.Math;
using LoLRunes.CustumData;
using LoLRunes.Domain.Services;

namespace LoLRunes.Domain.WindowInteraction.Services
{
    public class RunePagePositionService
    {
        #region Singleton
        public static RunePagePositionService _instance;

        public static RunePagePositionService instance
        {
            get
            {
                if(_instance == null)
                    _instance = new RunePagePositionService();

                return _instance;
            }
        }
        #endregion

        private static bool fisrtInitDone = false;
        private static RunePositionReferenceEnum[] mainPathRunesOrder;
        private static RunePositionReferenceEnum[] sidePathRunesOrder;
        private static ResolutionRunePositionConfig resolutionRunePositionConfig;
        private static Dictionary<Tuple<RunePositionReferenceEnum, PathTypeEnum>, Point> runePositionDict;

        private CalibrationService calibrationService;

        private RunePagePositionService()
        {
            calibrationService = new CalibrationService();

            if (!fisrtInitDone)
                FirstInit();
        }

        public void FirstInit()
        {
            mainPathRunesOrder = new RunePositionReferenceEnum[5]
            {
                RunePositionReferenceEnum.PATH_01,
                RunePositionReferenceEnum.PATH_02,
                RunePositionReferenceEnum.PATH_03,
                RunePositionReferenceEnum.PATH_04,
                RunePositionReferenceEnum.PATH_05
            };

            sidePathRunesOrder = new RunePositionReferenceEnum[4]
            {
                RunePositionReferenceEnum.PATH_01,
                RunePositionReferenceEnum.PATH_02,
                RunePositionReferenceEnum.PATH_03,
                RunePositionReferenceEnum.PATH_04
            };

            fisrtInitDone = true;
        }

        public void MapPositionConfig(ResolutionRunePositionConfig resolutionRunePositionConfig)
        {
            RunePagePositionService.resolutionRunePositionConfig = resolutionRunePositionConfig;

            runePositionDict = new Dictionary<Tuple<RunePositionReferenceEnum, PathTypeEnum>, Point>();

            #region Map Main Path
            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.PATH_01, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainPath_01.x,
                    resolutionRunePositionConfig.RunePagePositions.mainPath_01.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.PATH_02, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainPath_02.x,
                    resolutionRunePositionConfig.RunePagePositions.mainPath_02.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.PATH_03, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainPath_03.x,
                    resolutionRunePositionConfig.RunePagePositions.mainPath_03.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.PATH_04, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainPath_04.x,
                    resolutionRunePositionConfig.RunePagePositions.mainPath_04.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.PATH_05, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainPath_05.x,
                    resolutionRunePositionConfig.RunePagePositions.mainPath_05.y));
            #endregion

            #region Map Side Path
            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.PATH_01, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sidePath_01.x,
                    resolutionRunePositionConfig.RunePagePositions.sidePath_01.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.PATH_02, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sidePath_02.x,
                    resolutionRunePositionConfig.RunePagePositions.sidePath_02.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.PATH_03, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sidePath_03.x,
                    resolutionRunePositionConfig.RunePagePositions.sidePath_03.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.PATH_04, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sidePath_04.x,
                    resolutionRunePositionConfig.RunePagePositions.sidePath_04.y));
            #endregion

            #region Map Key Stones
            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.KEYSTONE_01_01, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.keyStone_01_01.x,
                    resolutionRunePositionConfig.RunePagePositions.keyStone_01_01.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.KEYSTONE_01_02, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.keyStone_01_02.x,
                    resolutionRunePositionConfig.RunePagePositions.keyStone_01_02.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.KEYSTONE_01_03, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.keyStone_01_03.x,
                    resolutionRunePositionConfig.RunePagePositions.keyStone_01_03.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.KEYSTONE_01_04, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.keyStone_01_04.x,
                    resolutionRunePositionConfig.RunePagePositions.keyStone_01_04.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.KEYSTONE_02_01, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.keyStone_02_01.x,
                    resolutionRunePositionConfig.RunePagePositions.keyStone_02_01.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.KEYSTONE_02_02, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.keyStone_02_02.x,
                    resolutionRunePositionConfig.RunePagePositions.keyStone_02_02.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.KEYSTONE_02_03, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.keyStone_02_03.x,
                    resolutionRunePositionConfig.RunePagePositions.keyStone_02_03.y));
            #endregion

            #region Map Main Path Rune Slots
            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_01_01, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_01_01.x,
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_01_01.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_01_02, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_01_02.x,
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_01_02.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_01_03, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_01_03.x,
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_01_03.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_02_01, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_02_01.x,
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_02_01.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_02_02, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_02_02.x,
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_02_02.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_02_03, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_02_03.x,
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_02_03.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_03_01, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_03_01.x,
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_03_01.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_03_02, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_03_02.x,
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_03_02.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_03_03, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_03_03.x,
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_03_03.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_04_01, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_04_01.x,
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_04_01.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_04_02, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_04_02.x,
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_04_02.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_04_03, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_04_03.x,
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_04_03.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_04_04, PathTypeEnum.MAIN),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_04_04.x,
                    resolutionRunePositionConfig.RunePagePositions.mainRuneSlot_04_04.y));
            #endregion

            #region Map Side Path Rune Slots
            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_01_01, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_01_01.x,
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_01_01.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_01_02, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_01_02.x,
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_01_02.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_01_03, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_01_03.x,
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_01_03.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_02_01, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_02_01.x,
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_02_01.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_02_02, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_02_02.x,
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_02_02.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_02_03, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_02_03.x,
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_02_03.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_03_01, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_03_01.x,
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_03_01.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_03_02, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_03_02.x,
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_03_02.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_03_03, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_03_03.x,
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_03_03.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_04_01, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_04_01.x,
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_04_01.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_04_02, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_04_02.x,
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_04_02.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_04_03, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_04_03.x,
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_04_03.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.RUNE_SLOT_04_04, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_04_04.x,
                    resolutionRunePositionConfig.RunePagePositions.sideRuneSlot_04_04.y));
            #endregion

            #region Map Shard Slots
            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.SHARDS_SLOT_01_01, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_01_01.x,
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_01_01.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.SHARDS_SLOT_01_02, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_01_02.x,
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_01_02.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.SHARDS_SLOT_01_03, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_01_03.x,
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_01_03.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.SHARDS_SLOT_02_01, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_02_01.x,
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_02_01.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.SHARDS_SLOT_02_02, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_02_02.x,
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_02_02.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.SHARDS_SLOT_02_03, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_02_03.x,
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_02_03.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.SHARDS_SLOT_03_01, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_03_01.x,
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_03_01.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.SHARDS_SLOT_03_02, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_03_02.x,
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_03_02.y));

            runePositionDict.Add(
                new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.SHARDS_SLOT_03_03, PathTypeEnum.SIDE),
                new Point(
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_03_03.x,
                    resolutionRunePositionConfig.RunePagePositions.shardSlot_03_03.y));
            #endregion
        }

        public bool GetRunePosition(RunePositionReferenceEnum runePositionReference, PathTypeEnum pathType, out Point point)
        {
            if (runePositionDict == null)
                throw new NullReferenceException("Rune position not mapped!");            

            if (!runePositionDict.TryGetValue(new Tuple<RunePositionReferenceEnum, PathTypeEnum>(runePositionReference, pathType), out point))
                return false;

            Point precision_main = runePositionDict[new Tuple<RunePositionReferenceEnum, PathTypeEnum>(RunePositionReferenceEnum.PATH_01, PathTypeEnum.MAIN)];
            Point2D reference_precision_main = calibrationService.ReadCalibrationPoint();

            float x_proportion = MathUtils.RuleOfThree(precision_main.X, 1, reference_precision_main.x);
            float y_proportion = MathUtils.RuleOfThree(precision_main.Y, 1, reference_precision_main.y);

            point.X = (int)(point.X * x_proportion);
            point.Y = (int)(point.Y * y_proportion);

            if (ProgramManager.instance.runeMenu == RuneMenuEnum.CHAMPION_SELECTION_SCREEN)
            {
                Point offSet;

                offSet.X = (int)(resolutionRunePositionConfig.ChampionScreenOffSet.X * x_proportion);
                offSet.Y = (int)(resolutionRunePositionConfig.ChampionScreenOffSet.Y * y_proportion);

                point += (Size)offSet;
            }
            
            return true;
        }

        public bool GetSidePathRunePosition(RunePositionReferenceEnum sideRunePositionReference, RunePositionReferenceEnum mainRunePositionReference, out Point point)
        {
            if (!mainPathRunesOrder.Contains(sideRunePositionReference))
                throw new Exception("The informed rune position must be a 'PATH'");

            int sidePathOrderIndex = 0;

            foreach (var runePosition in mainPathRunesOrder)
            {
                if (runePosition == mainRunePositionReference)
                    continue;
                else if (runePosition == sideRunePositionReference)
                    break;

                sidePathOrderIndex++;
            }

            return GetRunePosition(sidePathRunesOrder[sidePathOrderIndex], PathTypeEnum.SIDE, out point);
        }
    }
}