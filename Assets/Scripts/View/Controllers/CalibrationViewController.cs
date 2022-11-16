using LoLRunes.Application.Services.Interfaces;
using UnityEngine;
using Zenject;

namespace LoLRunes.View.Controllers
{
    public class CalibrationViewController : MonoBehaviour
    {
        ICalibrationAppService calibrationAppService;

        [Inject]
        public void Construct(ICalibrationAppService calibrationAppService)
        {
            this.calibrationAppService = calibrationAppService;
        }

        public void StartCalibration()
        {
            calibrationAppService.StartCalibration();
        }

        public void StartPositionCalibration()
        {
            calibrationAppService.StartPositionCalibration();
        }

        public void CompletePositionCalibration()
        {
            calibrationAppService.CompletePositionCalibration();
        }
    }
}
