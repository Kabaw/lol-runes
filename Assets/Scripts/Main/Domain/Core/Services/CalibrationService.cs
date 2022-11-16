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
        private ICalibrationRepository calibrationRepository;

        [Inject]
        public CalibrationService(ICalibrationRepository calibrationRepository)
        {
            this.calibrationRepository = calibrationRepository;
        }

        public Point2D ReadCalibrationPoint()
        {
            return calibrationRepository.ReadCalibrationPoint();
        }

        public void SaveCalibrationPoint(Point2D point)
        {
            calibrationRepository.SaveCalibrationPoint(point);
        }
    }
}