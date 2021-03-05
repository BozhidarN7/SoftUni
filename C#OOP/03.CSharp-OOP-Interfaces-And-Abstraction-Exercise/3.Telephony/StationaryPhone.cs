using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Telephony
{
    public class StationaryPhone : Phone
    {
        public override string Call(string number)
        {
            Validator.ThrowIfNumberIsInValid(number);
            return $"Dialing... {number}";
        }
    }
}
