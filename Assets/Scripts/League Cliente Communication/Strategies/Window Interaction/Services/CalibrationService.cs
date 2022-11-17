using LoLRunes.Domain.Repositories;
using LoLRunes.LeagueClienteCommunication.Strategies.WindowInteraction.Services.Interfaces;
using LoLRunes.Shared.CustumData;
using Zenject;

namespace LoLRunes.LeagueClienteCommunication.Strategies.WindowInteraction.Services
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