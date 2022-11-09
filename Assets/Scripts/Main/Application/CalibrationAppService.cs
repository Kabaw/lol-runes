﻿using LoLRunes.View.ViewModel;
using LoLRunes.Domain.Commands;
using LoLRunes.Domain.Services;
using LoLRunes.Domain.Models;

namespace LoLRunes.Application.Services
{   
    public class CalibrationAppService
    {
        private CalibrationService calibrationService;

        public CalibrationAppService()
        {
            calibrationService = new CalibrationService();
        }

        public void StartCalibration()
        {
            calibrationService.StartCalibration();
        }

        public void StartPositionCalibration()
        {
            calibrationService.StartPositionCalibration();
        }

        public void CompletePositionCalibration()
        {
            calibrationService.CompletePositionCalibration();
        }
    }
}