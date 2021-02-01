using System;
using System.Linq;

namespace _2.KnightsOfHonor
{
    class KnightsOfHonor
    { 
        static void Main(string[] args)
        {
            Action<string> appendSirAndPrint = str =>
            {
                str = "Sir " + str;
                Console.WriteLine(str);
            };
            Console.ReadLine().Split().ToList().ForEach(x =>
            {
                appendSirAndPrint(x);
            });
        }


    }
}
