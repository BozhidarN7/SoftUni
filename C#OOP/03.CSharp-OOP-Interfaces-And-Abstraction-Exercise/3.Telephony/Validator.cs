using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Telephony
{
    public static class Validator
    {
        public static void ThrowIfNumberIsInValid(string number)
        {
            if (number.Any(x => !char.IsNumber(x)))
            {
                throw new InvalidOperationException("Invalid number!");
            }
        }

        public static void ThrowIfURLIsInvalid(string url)
        {
            if (url.Any(x => char.IsNumber(x)))
            {
                throw new InvalidOperationException("Invalid URL!");
            }
        }
    }
}
