namespace LoLRunes.LeagueClienteCommunication.Strategies.WindowInteraction.Services.Interfaces
{
    public interface IWindowCalibrationService
    {
        void StartCalibration();
        void StartPositionCalibration();
        void CompletePositionCalibration();
    }
}