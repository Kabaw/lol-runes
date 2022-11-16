using LoLRunes.CustumData;
using LoLRunes.Domain.Repositories;
using System;
using System.IO;
using UnityEngine;
using Zenject;

namespace LoLRunes.Infra
{
    public class CalibrationRepository : ICalibrationRepository
    {
        private static readonly string CALIBRATION_FILE_NAME = "calibration.txt";

        [Inject]
        public CalibrationRepository() { }

        public void SaveCalibrationPoint(Point2D point)
        {
            string calibrationFilePath = UnityEngine.Application.persistentDataPath + "/" + CALIBRATION_FILE_NAME;
            string json = JsonUtility.ToJson(point);

            File.WriteAllText(calibrationFilePath, json);
        }

        public Point2D ReadCalibrationPoint()
        {
            string json;
            string calibrationFilePath = UnityEngine.Application.persistentDataPath + "/" + CALIBRATION_FILE_NAME;

            try
            {
                json = File.ReadAllText(calibrationFilePath);

                Point2D point = JsonUtility.FromJson<Point2D>(json);

                return point;
            }
            catch (Exception)
            {
                throw new Exception("Error when attempting to read the calibration data.");
            }
        }
    }
}