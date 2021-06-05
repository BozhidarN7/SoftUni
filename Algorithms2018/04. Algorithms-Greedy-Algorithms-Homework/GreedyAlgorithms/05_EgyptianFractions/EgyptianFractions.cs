using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_EgyptianFractions
{
    class EgyptianFractions
    {
        private static List<int> result = new List<int>();

        static void Main(string[] args)
        {
            var number = Console.ReadLine().Split('/');

            var numerator = long.Parse(number[0]);
            var denumerator = long.Parse(number[1]);

            if (denumerator < numerator)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            Console.Write($"{numerator}/{denumerator} = ");

            var index = 2;

            while (numerator != 0)
            {
                var nextEnumerator = numerator * index;
                var indexNumerator = denumerator;

                var remaining = nextEnumerator - indexNumerator;

                if (remaining < 0)
                {
                    index++;
                    continue;
                }

                result.Add(index);

                numerator = remaining;
                denumerator = denumerator * index;

                index++;
            }

            Console.WriteLine(string.Join(" + ",result.Select(x => $"1/{x}")));
        }
    }
}
