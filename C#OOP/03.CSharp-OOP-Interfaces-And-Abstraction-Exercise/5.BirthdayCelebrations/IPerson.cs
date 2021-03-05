using System;
using System.Collections.Generic;
using System.Text;

namespace _5.BirthdayCelebrations
{
    public interface IPerson : IIdentifiable, IPet
    {
        public string Name { get; }
        public int Age { get; }
    }
}
