using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace _4.DrumSet
{
    class DrumSet
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumsInitialQuality = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> drums = new List<int>();
            for (int i = 0; i < drumsInitialQuality.Count; i++)
            {
                drums.Add(drumsInitialQuality[i]);
            }

            string input = Console.ReadLine();
            while (input != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);

                for (int i = 0; i < drums.Count; i++)
                {
                    drums[i] -= hitPower;
                    if (drums[i] <= 0)
                    {
                        if (savings >= drumsInitialQuality[i] * 3)
                        {
                            drums[i] = drumsInitialQuality[i];
                            savings -= drumsInitialQuality[i] * 3;
                        }

                    }
                }
                for (int i = 0; i < drums.Count; i++)
                {
                    if (drums[i] <= 0)
                    {
                        drums.Remove(drums[i]);
                        drumsInitialQuality.Remove(drumsInitialQuality[i]);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", drums));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
