using Beezilla.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beezilla
{
    
    public static class SwarmRisk
    {
        private static int value = 0;
        
        static int PopChecker(HiveModel hiveModel)
        {
            if (hiveModel.Size == "High")
            {
                value += 2;
                return value;
            }
            else if (hiveModel.Size == "AboveAverage")
            {
                value += 1;
                return value;
            }
            else if (hiveModel.Size == "Average")
            {
                return value;
            }
            else if (hiveModel.Size == "Low")
            {
                value -= 1;
                return value;
            }
            else if (hiveModel.Size == "VeryLow")
            {
                value -= 2;
                return value;
            }
            else
            {
                return value;
            }
        }
        static int BroodChecker(HiveModel hiveModel)
        {
            if (hiveModel.NumberOfFrames <= 20 && hiveModel.NumberOfFrames >=16 && hiveModel.Brood > 4)
            {
                value += 2;
                return value;
            }
            else if (hiveModel.NumberOfFrames <= 20 && hiveModel.NumberOfFrames >=16 && hiveModel.Brood <5 && hiveModel.Brood > 1)
            {
                value += 1;
                return value;
            }
            else if (hiveModel.NumberOfFrames <= 20 && hiveModel.NumberOfFrames >=16 && hiveModel.Brood <= 1)
            {
                value -= 3;
                return value;
            }
            else if (hiveModel.NumberOfFrames <= 16 && hiveModel.Brood > 2)
            {
                value += 2;
                return value;
            }
            else if (hiveModel.NumberOfFrames <= 16 && hiveModel.Brood == 2)
            {
                value += 1;
                return value;
            }
            else if (hiveModel.NumberOfFrames <= 16 && hiveModel.Brood < 2)
            {
                value -= 3;
                return value;
            }
            else
            {
                return value;
            }
        }
        static int QueenCellChecker(HiveModel hiveModel)
        {
            DateTime currentMonth;
            currentMonth = DateTime.Now;
            int month = currentMonth.Month;
            int march = 3;
            int april = 4;
            int may = 5;
            if (hiveModel.NumberOfFrames <= 20 && hiveModel.NumberOfFrames >= 16 && hiveModel.QueenCells > 5 && month == march || month == april || month == may)
            {
                value += 3;
                return value;
            }
            else if(hiveModel.NumberOfFrames <= 20 && hiveModel.NumberOfFrames >= 16 && hiveModel.QueenCells <=5 && hiveModel.QueenCells > 1 && month == march || month == april || month == may)
            {
                value += 1;
                return value;
            }
            else if(hiveModel.NumberOfFrames <=16 && hiveModel.QueenCells > 3 && month == march || month == april || month == may)
            {
                value += 2;
                return value;
            }
            else if(hiveModel.NumberOfFrames <= 16 && hiveModel.QueenCells < 3 && month == march || month == april || month == may)
            {
                value += 1;
                return value;
            }
            else
            {
                value -= 2;
                return value;
            }
        }
        public static string StringValue(int value)
        {
            string low = "Low Risk";
            string average = "Average Risk";
            string high = "High Risk";
            if (value > 5)
            {

                return high;
            }
            else if (value > 3 && value <= 5)
            {

                return average;
            }
            else if (value <= 3)
            {

                return low;
            }
            else
            {
                string error = "Sorry There Was a Problem!";
                return error;
            }
        }
        public static string SwarmCalc(HiveModel hiveModel)
        {
            int valueSwarm = PopChecker(hiveModel) + BroodChecker(hiveModel) + QueenCellChecker(hiveModel);
            string valueString = StringValue(valueSwarm);
            return valueString;
        }
    }
}
