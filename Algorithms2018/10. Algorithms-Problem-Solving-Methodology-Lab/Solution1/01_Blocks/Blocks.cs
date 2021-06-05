using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Blocks
{
    class Blocks
    {
        static void Main(string[] args)
        {
            int numberOfLetters = int.Parse(Console.ReadLine());

            Console.WriteLine("Number of blocks: {0}", (numberOfLetters - 3) * (numberOfLetters - 2) * (numberOfLetters - 1) * numberOfLetters / 4);

            var lastLetter = 'A' + numberOfLetters - 1;

            for (char l1 = 'A'; l1 <= lastLetter; l1++)
            {
                for (char l2 = (char)(l1 + 1); l2 <= lastLetter; l2++)
                {
                    for (char l3 = (char)(l1 + 1); l3 <= lastLetter; l3++)
                    {
                        if (l3 != l2)
                        {
                            for (char l4 = (char)(l1 + 1); l4 <= lastLetter; l4++)
                            {
                                if (l4 != l3 && l4 != l2)
                                {
                                    Console.WriteLine($"{l1}{l2}{l3}{l4}");
                                }
                            }

                        }
                    }
                }
            }
        }
    }
}
