using LoLRunes.CustumData;

namespace LoLRunes.Domain.Interfaces
{
    public interface IWindowCalibrationService
    {
        void StartCalibration();
        void StartPositionCalibration();
        void CompletePositionCalibration();
    }
}