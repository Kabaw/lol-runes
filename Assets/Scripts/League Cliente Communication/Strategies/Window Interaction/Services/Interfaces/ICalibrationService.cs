using LoLRunes.Shared.CustumData;

namespace LoLRunes.LeagueClienteCommunication.Strategies.WindowInteraction.Services.Interfaces
{
    public interface ICalibrationService
    {
        Point2D ReadCalibrationPoint();
        public void SaveCalibrationPoint(Point2D point);
    }
}