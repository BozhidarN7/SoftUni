using System;
using System.Collections.Generic;
using System.Text;

namespace _7.Tuple
{
    public class Tuple<TFirst,TSecond>
    {
        private TFirst item1;
        private TSecond item2;

        public Tuple(TFirst item1, TSecond item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
        public TFirst Item1 { get; set; }
        public TSecond Item2 { get; set; }
    }
}
