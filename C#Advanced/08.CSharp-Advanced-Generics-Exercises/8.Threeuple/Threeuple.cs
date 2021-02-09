using System;
using System.Collections.Generic;
using System.Text;

namespace _8.Threeuple
{
    class Threeuple<TFirst, TSecond,TThird>
    {
        private TFirst item1;
        private TSecond item2;
        private TThird item3;

        public Threeuple(TFirst item1, TSecond item2,TThird item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }
        public TFirst Item1 { get; set; }
        public TSecond Item2 { get; set; }
        public TThird Item3 { get; set; }
        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}
