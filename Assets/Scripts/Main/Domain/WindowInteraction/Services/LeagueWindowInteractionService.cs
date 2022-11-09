using LoLRunes.CustumData;
using LoLRunes.Domain.Models;
using LoLRunes.Domain.WindowInteraction.Services;
using LoLRunes.Enumerators;
using LoLRunes.Enumerators.Extensions;
using LoLRunes.Program.Managers;
using LoLRunes.ScriptableObjects;
using LoLRunes.Utils.User32;
using System.Collections;
using System.Drawing;
using UnityEngine;

namespace LoLRunes.Domain.Services
{
    public class LeagueWindowInteractionService
    {
        private static readonly string LOL_WINDOW_NAME = "League of Legends";
        private static readonly string LOL_PROCESS_NAME = "LeagueClientUx";

        public LeagueWindowInteractionService()
        {

        }

        public void SetFrontWindow()
        {
            WindowController.SetFrontWindow(LOL_PROCESS_NAME, LOL_WINDOW_NAME);
        }

        public Point2D GetWindowTopLeftPoint()
        {
            WindowPlacement windowPlacement = new WindowPlacement();

            WindowController.GetWindowPlacementInfo(LOL_PROCESS_NAME, LOL_WINDOW_NAME, ref windowPlacement);

            return new Point2D(windowPlacement.rcNormalPosition.left, windowPlacement.rcNormalPosition.top);
        }

        //Aplica a configuração de runas na janela do LOL
        public void ApplyRunePage(RunePage runePage)
        {
            SetFrontWindow();

            ProgramManager.instance.RunAsync(SelectRunes(runePage));
        }

        public IEnumerator SelectRunes(RunePage runePage)
        {
            Point point;
            Size windowReferencePosition;

            Point2D windowTopLeftPoint = GetWindowTopLeftPoint();

            windowReferencePosition = new Size(windowTopLeftPoint.x, windowTopLeftPoint.y);

            #region MainPath
            if (RunePagePositionService.instance.GetRunePosition(runePage.MainPath.RuneType.GetPositionReference(), PathTypeEnum.MAIN, out point))
                MouseController.LeftClick(point + windowReferencePosition);

            yield return new WaitForSeconds(0.2f);
            #endregion

            #region KeyStone
            if (RunePagePositionService.instance.GetRunePosition(runePage.KeyStone.RuneType.GetPositionReference(), PathTypeEnum.MAIN, out point))
                MouseController.LeftClick(point + windowReferencePosition);
            #endregion

            #region MainRunes
            if (RunePagePositionService.instance.GetRunePosition(runePage.MainPathRune_01.RuneType.GetPositionReference(), PathTypeEnum.MAIN, out point))
                MouseController.LeftClick(point + windowReferencePosition);

            if (RunePagePositionService.instance.GetRunePosition(runePage.MainPathRune_02.RuneType.GetPositionReference(), PathTypeEnum.MAIN, out point))
                MouseController.LeftClick(point + windowReferencePosition);

            if (RunePagePositionService.instance.GetRunePosition(runePage.MainPathRune_03.RuneType.GetPositionReference(), PathTypeEnum.MAIN, out point))
                MouseController.LeftClick(point + windowReferencePosition);
            #endregion

            #region SidePath
            if (RunePagePositionService.instance.GetSidePathRunePosition(
                    runePage.SidePath.RuneType.GetPositionReference(),
                    runePage.MainPath.RuneType.GetPositionReference(),
                    out point))
                MouseController.LeftClick(point + windowReferencePosition);

            yield return new WaitForSeconds(0.2f);
            #endregion

            #region SideRunes
            if (RunePagePositionService.instance.GetRunePosition(runePage.SidePathRune_01.RuneType.GetPositionReference(), PathTypeEnum.SIDE, out point))
                MouseController.LeftClick(point + windowReferencePosition);

            if (RunePagePositionService.instance.GetRunePosition(runePage.SidePathRune_02.RuneType.GetPositionReference(), PathTypeEnum.SIDE, out point))
                MouseController.LeftClick(point + windowReferencePosition);
            #endregion

            #region Shards
            if (RunePagePositionService.instance.GetRunePosition(runePage.RuneShardAttack.RuneType.GetPositionReference(), PathTypeEnum.SIDE, out point))
                MouseController.LeftClick(point + windowReferencePosition);

            if (RunePagePositionService.instance.GetRunePosition(runePage.RuneShardFlex.RuneType.GetPositionReference(), PathTypeEnum.SIDE, out point))
                MouseController.LeftClick(point + windowReferencePosition);

            if (RunePagePositionService.instance.GetRunePosition(runePage.RuneShardDefence.RuneType.GetPositionReference(), PathTypeEnum.SIDE, out point))
                MouseController.LeftClick(point + windowReferencePosition);
            #endregion
        }
    }
}