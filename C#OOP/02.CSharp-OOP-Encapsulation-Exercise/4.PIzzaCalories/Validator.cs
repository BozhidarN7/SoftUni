using System;
using System.Collections.Generic;
using System.Text;

namespace _4.PIzzaCalories
{
    public static class Validator
    {
        public static void ThrowIfInvalidType(HashSet<string> allowedTypes, string type, string message)
        {
            if (!allowedTypes.Contains(type))
            {
                throw new ArgumentException(message);
            }
        }
        public static void ThrowIfNumberIsNotInRange(int min, int max,int number, string message)
        {
            if (number < min || number > max)
            {
                throw new ArgumentException(message);
            }
        }

    }
}
