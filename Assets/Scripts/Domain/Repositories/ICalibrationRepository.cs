using LoLRunes.Shared.CustumData;

namespace LoLRunes.Domain.Repositories
{
    public interface ICalibrationRepository
    {
        Point2D ReadCalibrationPoint();
        void SaveCalibrationPoint(Point2D point);
    }
}