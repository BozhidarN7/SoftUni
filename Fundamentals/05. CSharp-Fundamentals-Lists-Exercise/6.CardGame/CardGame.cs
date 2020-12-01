using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.CardGame
{
    class CardGame
    {
        static void Main(string[] args)
        {
            List<int> deckOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> deckTwo = Console.ReadLine().Split().Select(int.Parse).ToList();

            int index = 0;
            while (deckOne.Count != 0 && deckTwo.Count != 0)
            {
                if (deckOne[index] > deckTwo[index])
                {
                    int number = deckOne[index];
                    deckOne.RemoveAt(index);
                    deckOne.Add(number);

                    number = deckTwo[index];
                    deckTwo.RemoveAt(index);
                    deckOne.Add(number);
                }
                else if (deckOne[index] < deckTwo[index])
                {
                    int number = deckTwo[index];
                    deckTwo.RemoveAt(index);
                    deckTwo.Add(number);

                    number = deckOne[index];
                    deckOne.RemoveAt(index);
                    deckTwo.Add(number);
                }
                else
                {
                    deckOne.RemoveAt(index);
                    deckTwo.RemoveAt(index);
                }
            }

            if (deckTwo.Count == 0)
            {
                Console.WriteLine($"First player wins! Sum: {deckOne.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {deckTwo.Sum()}");
            }
        }
    }
}
