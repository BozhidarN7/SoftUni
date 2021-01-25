using System;
using System.IO;

namespace _1.OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            string directory = Environment.CurrentDirectory;
            Console.WriteLine(directory);
            using (StreamReader reader = new StreamReader(@"../../../../Resources/01.OddLines/input.txt")) // Use your path here
            {
                string line = reader.ReadLine();
                int row = 0;
                while (line != null)
                {
                    if (row % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }
                    row++;
                    line = reader.ReadLine();
                }
            }

        }
    }
}
