using LoLRunes.View.ViewModel;
using LoLRunes.Domain.Commands;
using LoLRunes.Domain.Services;
using LoLRunes.Domain.Models;
using LoLRunes.Domain.Interfaces;

namespace LoLRunes.Application.Services
{   
    public class CalibrationAppService
    {
        private ICalibrationService calibrationService;

        public CalibrationAppService(ICalibrationService calibrationService)
        {
            this.calibrationService = calibrationService;
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
