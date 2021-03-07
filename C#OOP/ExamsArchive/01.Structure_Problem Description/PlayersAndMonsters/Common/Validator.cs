using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Common
{
    public static class Validator
    {
        public static void ThrowIfStringIsInvalid(string name,string message)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(message);
            }
        }
        public static void ThrowIfNumberIsNegative(int number,string message)
        {
            if (number < 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
