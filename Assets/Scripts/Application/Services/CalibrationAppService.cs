using LoLRunes.View.ViewModel;
using LoLRunes.Domain.Commands;
using LoLRunes.Domain.Services;
using LoLRunes.Domain.Models;
using LoLRunes.Domain.Interfaces;
using UnityEngine;

namespace LoLRunes.Application.Services
{
    public class CalibrationAppService : ICalibrationAppService
    {
        private IWindowCalibrationService windowCalibrationService;

        public CalibrationAppService(IWindowCalibrationService windowCalibrationService)
        {
            this.windowCalibrationService = windowCalibrationService;
        }

        public void StartCalibration()
        {
            windowCalibrationService.StartCalibration();
        }

        public void StartPositionCalibration()
        {
            windowCalibrationService.StartPositionCalibration();
        }

        public void CompletePositionCalibration()
        {
            windowCalibrationService.CompletePositionCalibration();
        }
    }
}
