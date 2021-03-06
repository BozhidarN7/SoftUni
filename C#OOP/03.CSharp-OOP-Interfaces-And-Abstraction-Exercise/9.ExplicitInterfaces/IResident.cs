using System;
using System.Collections.Generic;
using System.Text;

namespace _9.ExplicitInterfaces
{
    public interface IResident
    {
        public string Name { get; }
        public string Country { get; }
        public string GetName();
    }
}
