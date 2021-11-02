using LoLRunes.Domain.Models;
using LoLRunes.Domain.Commands;
using LoLRunes.ScriptableObjects;
using LoLRunes.Program.Managers;
using LoLRunes.Utils.User32;
using LoLRunes.CustumData;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Gma.UserActivityMonitor;
using System.Linq;

namespace LoLRunes.Domain.Services
{
    public class CalibrationService
    {
        private bool isCalibrating = false;
        private Point2D windowTopLeft;
        private List<Point2D> calibrationPoints;

        private LeagueWindowInteractionService windowInteractionService;

        public CalibrationService()
        {
            windowInteractionService = new LeagueWindowInteractionService();
        }

        public void StartCalibration()
        {
            isCalibrating = true;
            calibrationPoints = new List<Point2D>();
            windowTopLeft = windowInteractionService.GetWindowTopLeftPoint();

            windowInteractionService.SetFrontWindow();

            MSWindowsEventManager.instance.Subscribe_MouseDown(CalibrationClick_HookManager);
        }

        public void CompleteCalibration()
        {
            if(!isCalibrating) return;

            MSWindowsEventManager.instance.Unsubscribe_MouseDown(CalibrationClick_HookManager);

            Debug.Log(string.Join("\n", calibrationPoints.Select(p => string.Format("{0:0000}, {1:0000}", p.x, p.y))));

            calibrationPoints = null;
            isCalibrating = false;
        }

        private void CalibrationClick_HookManager(object sender, MouseEventExtArgs e)
        {
            Point2D point = new Point2D();

            point.x = e.X - windowTopLeft.x;
            point.y = e.Y - windowTopLeft.y;

            calibrationPoints.Add(point);
        }
    }
}