using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Telephony
{
    public abstract class Phone : ICalable
    {
        public abstract string Call(string number);
        
    }
}
