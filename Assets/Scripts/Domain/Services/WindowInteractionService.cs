using LoLRunes.Domain.Models;
using LoLRunes.Enumerators.Extensions;
using LoLRunes.Program.Managers;
using LoLRunes.ScriptableObjects;
using LoLRunes.Utils.User32;
using System.Collections;
using System.Drawing;
using UnityEngine;

namespace LoLRunes.Domain.Services
{
    public class WindowInteractionService
    {
        private static readonly string LOL_WINDOW_NAME = "League of Legends";
        private static readonly string LOL_PROCESS_NAME = "LeagueClientUx";

        private ResolutionRunePositionConfig runePositionConfig;

        public WindowInteractionService()
        {
            runePositionConfig = ProgramManager.instance.resolutionRunePositionConfig;
        }

        //Aplica a configuração de runas na janela do LOL
        public void ApplyRunePage(RunePage runePage)
        {
            WindowController.SetFrontWindow(LOL_PROCESS_NAME, LOL_WINDOW_NAME);

            ProgramManager.instance.RunAsync(SelectRunes(runePage));
        }

        public IEnumerator SelectRunes(RunePage runePage)
        {
            Point point;

            point = false ? new Point() : runePositionConfig.ChampionScreenOffSet;

            #region MainPath
            point += (Size)runePositionConfig.GetRuneRelativePosition(runePage.MainPath.RuneType.GetPositionReference());
            MouseController.LeftClick(point);

            yield return new WaitForSeconds(0.1f);
            #endregion

            #region KeyStone
            point += (Size)runePositionConfig.GetRuneRelativePosition(runePage.KeyStone.RuneType.GetPositionReference());
            MouseController.LeftClick(point);
            #endregion

            #region MainRunes
            point += (Size)runePositionConfig.GetRuneRelativePosition(runePage.MainPathRune_01.RuneType.GetPositionReference());
            MouseController.LeftClick(point);

            point += (Size)runePositionConfig.GetRuneRelativePosition(runePage.MainPathRune_02.RuneType.GetPositionReference());
            MouseController.LeftClick(point);

            point += (Size)runePositionConfig.GetRuneRelativePosition(runePage.MainPathRune_03.RuneType.GetPositionReference());
            MouseController.LeftClick(point);
            #endregion

            #region SidePath
            point += (Size)runePositionConfig.GetRuneRelativePosition(runePage.SidePath.RuneType.GetPositionReference());
            MouseController.LeftClick(point);

            yield return new WaitForSeconds(0.1f);
            #endregion

            #region SideRunes
            point += (Size)runePositionConfig.GetRuneRelativePosition(runePage.SidePathRune_01.RuneType.GetPositionReference());
            MouseController.LeftClick(point);                           
                                                                        
            point += (Size)runePositionConfig.GetRuneRelativePosition(runePage.SidePathRune_02.RuneType.GetPositionReference());
            MouseController.LeftClick(point);
            #endregion

            #region Shards
            point += (Size)runePositionConfig.GetRuneRelativePosition(runePage.RuneShardAttack .RuneType.GetPositionReference());
            MouseController.LeftClick(point);

            point += (Size)runePositionConfig.GetRuneRelativePosition(runePage.RuneShardFlex.RuneType.GetPositionReference());
            MouseController.LeftClick(point);

            point += (Size)runePositionConfig.GetRuneRelativePosition(runePage.RuneShardDefence.RuneType.GetPositionReference());
            MouseController.LeftClick(point);
            #endregion
        }
    }
}