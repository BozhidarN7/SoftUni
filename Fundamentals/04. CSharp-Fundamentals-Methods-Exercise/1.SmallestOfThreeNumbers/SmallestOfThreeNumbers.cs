using System;

namespace _1.SmallestOfThreeNumbers
{
    class SmallestOfThreeNumbers
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());

            FindSmallestNumber(numOne, numTwo, numThree);
        }

        private static void FindSmallestNumber(int numOne, int numTwo, int numThree)
        {
            if (numOne <= numTwo && numOne <=numThree)
            {
                Console.WriteLine(numOne);
            }
            else if (numTwo <= numOne && numTwo <=numThree)
            {
                Console.WriteLine(numTwo);
            }
            else
            {
                Console.WriteLine(numThree);
            }
        }
    }
}
