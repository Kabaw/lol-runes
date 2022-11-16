using LoLRunes.CustumData;

namespace LoLRunes.Domain.Interfaces
{
    public interface ICalibrationService
    {
        void CompletePositionCalibration();
        Point2D ReadCalibrationPoint();
        void StartCalibration();
        void StartPositionCalibration();
    }
}