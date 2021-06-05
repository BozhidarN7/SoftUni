using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_StarInTheCube
{
    class StarInTheCube
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,,] cube = new char[size, size, size];

            for (int i = 0; i < size; i++)
            {
                var line = Console.ReadLine().Replace(" ", "").Split('|');

                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        cube[i, j, k] = line[j][k];
                    }
                }
            }

            int starsCount = 0;

            SortedDictionary<char, int> byLetters = new SortedDictionary<char, int>();

            for (int i = 1; i < size - 1; i++)
            {
                for (int j = 1; j < size - 1; j++)
                {
                    for (int k = 1; k < size - 1; k++)
                    {
                        char letter = cube[i, j, k];
                        bool hasStar =
                            (cube[i - 1, j, k] == letter) &&
                            (cube[i, j - 1, k] == letter) &&
                            (cube[i, j + 1, k] == letter) &&
                            (cube[i + 1, j, k] == letter) &&
                            (cube[i, j, k - 1] == letter) &&
                            (cube[i, j, k + 1] == letter);

                        if (hasStar)
                        {
                            starsCount++;

                            if (!byLetters.ContainsKey(letter))
                            {
                                byLetters[letter] = 1;
                            }
                            else
                            {
                                byLetters[letter]++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(starsCount);
            foreach (var pair in byLetters)
            {
                Console.WriteLine(pair.Key + " -> " + pair.Value);
            }
        }
    }
}
