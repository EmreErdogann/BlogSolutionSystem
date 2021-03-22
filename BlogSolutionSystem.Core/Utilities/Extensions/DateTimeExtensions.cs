using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSolutionSystem.Core.Utilities.Extensions
{
    public static class DateTimeExtensions
    {
        public static string FullDateAndTimeStringWithUnderscore(this DateTime dateTime)
        {
            //return $"{dateTime.Millisecond}_{dateTime.Second}_{dateTime.Minute}_{dateTime.Hour}_{dateTime.Day}_{dateTime.Year}";
            return $"{dateTime.Minute}_{dateTime.Hour}_{dateTime.Day}_{dateTime.Year}";

        }
    }
}
