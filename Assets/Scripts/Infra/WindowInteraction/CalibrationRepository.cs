using LoLRunes.CustumData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LoLRunes.Infra.Core
{
    public class CalibrationRepository
    {
        private static readonly string CALIBRATION_FILE_NAME = "calibration.txt";

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