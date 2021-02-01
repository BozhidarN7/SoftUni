using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public int DaysDifference { get; set; }
        public void CalculateDifference(string dateOne, string dateTwo)
        {
            DateTime firstDate = ConvertToDateType(dateOne);
            DateTime secondDate = ConvertToDateType(dateTwo);

            DaysDifference = Math.Abs((firstDate - secondDate).Days);
        }

        private DateTime ConvertToDateType(string date)
        {
            string[] tokens = date.Split();
            int year = int.Parse(tokens[0]);
            int month = int.Parse(tokens[1].StartsWith("0") ? tokens[1].Substring(1) : tokens[1]);
            int day = int.Parse(tokens[2].StartsWith("0") ? tokens[2].Substring(1) : tokens[2]);

            return new DateTime(year, month, day);
        }
    }
}
