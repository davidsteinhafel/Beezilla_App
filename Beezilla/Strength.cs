using Beezilla.Data;
using Beezilla.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beezilla
{
    public static class Strength
    {
        private static int value = 0;
        static int FrameChecker(HiveModel hiveModel)
        {

            int strengthValue = value;
            if(hiveModel.NumberOfFrames <= 4)
            {
                value -= 2;
                return value;
            }
            else if(hiveModel.NumberOfFrames >= 10 && hiveModel.NumberOfFrames <= 15)
            {
                value += 2;
                return value;
            }
            else if(hiveModel.NumberOfFrames >= 5 && hiveModel.NumberOfFrames <10)
            {
                value += 1;
                return value;
            }
            else
            {
                value += 5;
                return value;
            }
        }
        static int BroodPatternChecker(HiveModel hiveModel)
        {
            if (hiveModel.BroodPattern == "Solid")
            {
                value += 2;
                return value;
            }
            else if (hiveModel.BroodPattern == "Spotty")
            {
                value -= 2;
                return value;
            }
            else
            {
                value -= 2;
                return value;
            }
        }
        static int MiteChecker(HiveModel hiveModel)
        {
            DateTime currentMonth = new DateTime();
            DateTime endOfYear = new DateTime();
            currentMonth = DateTime.Now;
            endOfYear = DateTime.MaxValue;
            int lastMonth = endOfYear.Month;
            int month = currentMonth.Month;
            if(month >= 10)
            {
                return value;
            }
            else if(month >= 6 && month <= 9 && hiveModel.Mites >=6)
            {
                value -= 2;
                return value;
            }
            else if (month >= 3 && month <= 6 && hiveModel.Mites >=3)
            {
                value -= 2;
                return value;
            }
            else
            {
                value += 3;
                return value;
            }
        }
        public static int StrengthCalc(HiveModel hiveModel)
        {
            int valueStrength = FrameChecker(hiveModel) + BroodPatternChecker(hiveModel) + MiteChecker(hiveModel);
            return valueStrength;
        }
    }
}
