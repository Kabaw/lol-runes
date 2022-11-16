using LoLRunes.Shared.CustumData;

namespace LoLRunes.Domain.Services.Interfaces
{
    public interface ICalibrationService
    {
        Point2D ReadCalibrationPoint();
        public void SaveCalibrationPoint(Point2D point);
    }
}