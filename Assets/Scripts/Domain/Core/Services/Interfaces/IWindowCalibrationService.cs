namespace LoLRunes.Domain.Services.Interfaces
{
    public interface IWindowCalibrationService
    {
        void StartCalibration();
        void StartPositionCalibration();
        void CompletePositionCalibration();
    }
}