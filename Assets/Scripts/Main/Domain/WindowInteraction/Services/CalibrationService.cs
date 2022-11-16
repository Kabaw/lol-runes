using Gma.UserActivityMonitor;
using LoLRunes.CustumData;
using LoLRunes.Domain.Interfaces;
using LoLRunes.Domain.Repositories;
using LoLRunes.Utils.User32;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace LoLRunes.Domain.Services
{
    public class CalibrationService : ICalibrationService
    {
        private bool isCalibrating = false;
        private Point2D calibrationPoint;
        private Point2D windowTopLeft;
        private List<Point2D> calibrationPositionPoints;

        private ILeagueWindowInteractionService windowInteractionService;
        private ICalibrationRepository calibrationRepository;

        [Inject]
        public CalibrationService(ICalibrationRepository calibrationRepository, ILeagueWindowInteractionService leagueWindowInteractionService)
        {
            this.windowInteractionService = leagueWindowInteractionService;
            this.calibrationRepository = calibrationRepository;
        }

        public Point2D ReadCalibrationPoint()
        {
            return calibrationRepository.ReadCalibrationPoint();
        }

        public void StartCalibration()
        {
            if (isCalibrating)
                throw new Exception("Another calibration process is already running");

            isCalibrating = true;
            windowTopLeft = windowInteractionService.GetWindowTopLeftPoint();

            windowInteractionService.SetFrontWindow();

            MSWindowsEventManager.instance.Subscribe_MouseDown(Calibration_HookManager);
        }

        private void CompleteCalibration()
        {
            if (!isCalibrating) return;

            MSWindowsEventManager.instance.Unsubscribe_MouseDown(Calibration_HookManager);

            Point2D windowTopLeft = windowInteractionService.GetWindowTopLeftPoint();

            calibrationPoint -= windowTopLeft;

            calibrationRepository.SaveCalibrationPoint(calibrationPoint);

            isCalibrating = false;
        }

        public void StartPositionCalibration()
        {
            if (isCalibrating)
                throw new Exception("Another calibration process is already running");

            isCalibrating = true;
            calibrationPositionPoints = new List<Point2D>();
            windowTopLeft = windowInteractionService.GetWindowTopLeftPoint();

            windowInteractionService.SetFrontWindow();

            MSWindowsEventManager.instance.Subscribe_MouseDown(CalibrationPositionClick_HookManager);
        }

        public void CompletePositionCalibration()
        {
            if (!isCalibrating) return;

            MSWindowsEventManager.instance.Unsubscribe_MouseDown(CalibrationPositionClick_HookManager);

            Debug.Log(string.Join("\n", calibrationPositionPoints.Select(p => string.Format("{0:0000}, {1:0000}", p.x, p.y))));

            calibrationPositionPoints = null;
            isCalibrating = false;
        }

        private void Calibration_HookManager(object sender, MouseEventExtArgs e)
        {
            calibrationPoint.x = e.X;
            calibrationPoint.y = e.Y;

            CompleteCalibration();
        }

        private void CalibrationPositionClick_HookManager(object sender, MouseEventExtArgs e)
        {
            Point2D point = new Point2D();

            point.x = e.X - windowTopLeft.x;
            point.y = e.Y - windowTopLeft.y;

            calibrationPositionPoints.Add(point);
        }
    }
}