using LoLRunes.CustumData;
using LoLRunes.Domain.Repositories;
using LoLRunes.Domain.Services.Interfaces;
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