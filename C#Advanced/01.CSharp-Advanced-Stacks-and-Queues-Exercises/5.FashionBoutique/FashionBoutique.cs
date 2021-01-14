using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.FashionBoutique
{
    class FashionBoutique
    {
        static void Main(string[] args)
        {
            Stack<int> clothesValues = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());

            int rackcNeeded = 0;
            int spaceTakenSoFar = 0;
            while (clothesValues.Count != 0)
            {
                if (spaceTakenSoFar + clothesValues.Peek() <= rackCapacity)
                {
                    spaceTakenSoFar += clothesValues.Pop();
                }
                else
                {
                    rackcNeeded++;
                    spaceTakenSoFar = 0;
                }
            }
            if (spaceTakenSoFar != 0)
            {
                rackcNeeded++;
            }
            Console.WriteLine(rackcNeeded);
        }
    }
}
