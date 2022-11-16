using LoLRunes.CustumData;
using LoLRunes.Domain.Interfaces;
using LoLRunes.Domain.Models;
using LoLRunes.Enumerators;
using LoLRunes.Enumerators.Extensions;
using LoLRunes.Shared.Utils;
using LoLRunes.Utils.User32;
using System.Collections;
using System.Drawing;
using UnityEngine;
using Zenject;

namespace LoLRunes.Domain.Services
{
    public class LeagueWindowInteractionService : ILeagueWindowInteractionService
    {
        private readonly string LOL_WINDOW_NAME = "League of Legends";
        private readonly string LOL_PROCESS_NAME = "LeagueClientUx";
        private IRunePagePositionService runePagePositionService;

        [Inject]
        public LeagueWindowInteractionService(IRunePagePositionService runePagePositionService)
        {
            Debug.Log(ToString());
            this.runePagePositionService = runePagePositionService;
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

            AssyncOperationProvider.instance.RunAsync(SelectRunes(runePage));
        }

        private IEnumerator SelectRunes(RunePage runePage)
        {
            Point point;
            Size windowReferencePosition;

            Point2D windowTopLeftPoint = GetWindowTopLeftPoint();

            windowReferencePosition = new Size(windowTopLeftPoint.x, windowTopLeftPoint.y);

            #region MainPath
            if (runePagePositionService.GetRunePosition(runePage.MainPath.RuneType.GetPositionReference(), PathTypeEnum.MAIN, out point))
                MouseController.LeftClick(point + windowReferencePosition);

            yield return new WaitForSeconds(0.2f);
            #endregion

            #region KeyStone
            if (runePagePositionService.GetRunePosition(runePage.KeyStone.RuneType.GetPositionReference(), PathTypeEnum.MAIN, out point))
                MouseController.LeftClick(point + windowReferencePosition);
            #endregion

            #region MainRunes
            if (runePagePositionService.GetRunePosition(runePage.MainPathRune_01.RuneType.GetPositionReference(), PathTypeEnum.MAIN, out point))
                MouseController.LeftClick(point + windowReferencePosition);

            if (runePagePositionService.GetRunePosition(runePage.MainPathRune_02.RuneType.GetPositionReference(), PathTypeEnum.MAIN, out point))
                MouseController.LeftClick(point + windowReferencePosition);

            if (runePagePositionService.GetRunePosition(runePage.MainPathRune_03.RuneType.GetPositionReference(), PathTypeEnum.MAIN, out point))
                MouseController.LeftClick(point + windowReferencePosition);
            #endregion

            #region SidePath
            if (runePagePositionService.GetSidePathRunePosition(
                    runePage.SidePath.RuneType.GetPositionReference(),
                    runePage.MainPath.RuneType.GetPositionReference(),
                    out point))
                MouseController.LeftClick(point + windowReferencePosition);

            yield return new WaitForSeconds(0.2f);
            #endregion

            #region SideRunes
            if (runePagePositionService.GetRunePosition(runePage.SidePathRune_01.RuneType.GetPositionReference(), PathTypeEnum.SIDE, out point))
                MouseController.LeftClick(point + windowReferencePosition);

            if (runePagePositionService.GetRunePosition(runePage.SidePathRune_02.RuneType.GetPositionReference(), PathTypeEnum.SIDE, out point))
                MouseController.LeftClick(point + windowReferencePosition);
            #endregion

            #region Shards
            if (runePagePositionService.GetRunePosition(runePage.RuneShardAttack.RuneType.GetPositionReference(), PathTypeEnum.SIDE, out point))
                MouseController.LeftClick(point + windowReferencePosition);

            if (runePagePositionService.GetRunePosition(runePage.RuneShardFlex.RuneType.GetPositionReference(), PathTypeEnum.SIDE, out point))
                MouseController.LeftClick(point + windowReferencePosition);

            if (runePagePositionService.GetRunePosition(runePage.RuneShardDefence.RuneType.GetPositionReference(), PathTypeEnum.SIDE, out point))
                MouseController.LeftClick(point + windowReferencePosition);
            #endregion
        }
    }
}