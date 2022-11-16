using LoLRunes.Application.Services;
using LoLRunes.Enumerators;
using LoLRunes.Enumerators.Extensions;
using LoLRunes.View.UI;
using LoLRunes.View.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace LoLRunes.View.Controllers
{
    public class CalibrationViewController : MonoBehaviour
    {
        CalibrationAppService calibrationAppService;

        [Inject]
        public void Construct(CalibrationAppService calibrationAppService)
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
