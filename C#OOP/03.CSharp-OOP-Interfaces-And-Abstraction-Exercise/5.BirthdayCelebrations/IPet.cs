using System;
using System.Collections.Generic;
using System.Text;

namespace _5.BirthdayCelebrations
{
    public interface IPet : IBirthable
    {
        public string Name { get; }
    }
}
