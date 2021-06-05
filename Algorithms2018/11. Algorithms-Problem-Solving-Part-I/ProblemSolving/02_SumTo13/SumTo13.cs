using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SumTo13
{
    class SumTo13
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            if (numbers[0] + numbers[1] + numbers[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (numbers[0] - numbers[1] + numbers[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (numbers[0] - numbers[1] - numbers[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (numbers[0] + numbers[1] - numbers[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (-numbers[0] + numbers[1] - numbers[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (-numbers[0] - numbers[1] - numbers[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (-numbers[0] - numbers[1] + numbers[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (-numbers[0] + numbers[1] + numbers[2] == 13)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }


        }
    }
}
