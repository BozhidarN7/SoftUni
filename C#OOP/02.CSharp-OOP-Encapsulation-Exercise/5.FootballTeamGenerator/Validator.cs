using System;
using System.Collections.Generic;
using System.Text;

namespace _5.FootballTeamGenerator
{
    public static class Validator
    {
        public static void ThrowIfNameIsInvalid(string str, string message)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfStatIsNotInRange(int min, int max, int number, string message)
        {
            if (number < min || number > max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
