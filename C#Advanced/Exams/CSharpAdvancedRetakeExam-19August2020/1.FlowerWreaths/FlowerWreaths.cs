using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.FlowerWreaths
{
    class FlowerWreaths
    {
        static void Main(string[] args)
        {
            Stack<int> lillies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            int wreaths = 0;
            int remaining = 0;
            while(lillies.Count != 0 && roses.Count != 0)
            {
                int lilly = lillies.Pop();
                int rose = roses.Dequeue();

                int sum = lilly + rose;

                if (sum == 15)
                {
                    wreaths++;
                }
                else if( sum < 15)
                {
                    remaining += sum;
                }
                else
                {
                    if (sum % 2 != 0)
                    {
                        wreaths++;
                    }
                    else
                    {
                        remaining += 14;
                    }
                }
            }
            wreaths += remaining / 15;
            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5- wreaths} wreaths more!");
            }
        }
    }
}
