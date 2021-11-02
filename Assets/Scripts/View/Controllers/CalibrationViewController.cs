using LoLRunes.Application.Services;
using LoLRunes.Enumerators;
using LoLRunes.Enumerators.Extensions;
using LoLRunes.View.UI;
using LoLRunes.View.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoLRunes.View.Controllers
{
    public class CalibrationViewController : MonoBehaviour
    {
        CalibrationAppService calibrationAppService;

        private void Start()
        {
            calibrationAppService = new CalibrationAppService();
        }

        public void StartCalibration()
        {
            calibrationAppService.StartCalibration();
        }

        public void CompleteCalibration()
        {
            calibrationAppService.CompleteCalibration();
        }
    }
}
