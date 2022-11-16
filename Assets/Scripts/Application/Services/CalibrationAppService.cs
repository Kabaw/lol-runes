using LoLRunes.Application.Services.Interfaces;
using LoLRunes.Domain.Services.Interfaces;

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
