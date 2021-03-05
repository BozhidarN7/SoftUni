using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Telephony
{
    public class Smartphone : Phone, IBrowsable
    {
        public string Browse(string url)
        {
            Validator.ThrowIfURLIsInvalid(url);
            return $"Browsing: {url}!";
        }

        public override string Call(string number)
        {
            Validator.ThrowIfNumberIsInValid(number);
            return $"Calling... {number}";
        }
    }
}
