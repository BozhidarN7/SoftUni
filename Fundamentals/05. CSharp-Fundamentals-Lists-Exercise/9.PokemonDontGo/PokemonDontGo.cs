using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.PokemonDontGo
{
    class PokemonDontGo
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int index = int.Parse(Console.ReadLine());
            int sum = 0;
            while (true)
            {
                int value = numbers[0];
                if (index < 0)
                {
                    numbers[0] = numbers[numbers.Count - 1];
                    ChangeValue(numbers, value);
                    sum += value;
                }
                else if (index >= numbers.Count)
                {
                    value = numbers[numbers.Count - 1];
                    numbers[numbers.Count - 1] = numbers[0];
                    ChangeValue(numbers, value);
                    sum += value;
                }
                else
                {
                    value = numbers[index];
                    sum += value;
                    numbers.RemoveAt(index);

                    ChangeValue(numbers, value);
                }

                if (numbers.Count <= 0)
                {
                    break;
                }

                index = int.Parse(Console.ReadLine());

            }

            Console.WriteLine(sum);
        }

        private static void ChangeValue(List<int> numbers, int value)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] <= value)
                {
                    numbers[i] += value;
                }
                else
                {
                    numbers[i] -= value;
                }
            }
        }
    }
}
