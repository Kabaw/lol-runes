namespace LoLRunes.Application.Services.Interfaces
{
    public interface ICalibrationAppService
    {
        void CompletePositionCalibration();
        void StartCalibration();
        void StartPositionCalibration();
    }
}