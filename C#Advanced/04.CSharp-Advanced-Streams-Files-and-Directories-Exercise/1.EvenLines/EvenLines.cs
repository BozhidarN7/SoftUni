using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1.EvenLines
{
    class EvenLines
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader(@"../../../../text.txt"))
            {
                int row = 0;
                string line = reader.ReadLine();
                using (StreamWriter writer = new StreamWriter(@"../../../../output.txt"))
                {
                    while (line != null)
                    {
                        if ((row & 1) == 0)
                        {
                            line = Regex.Replace(line, @"[-,.!?]+", "@");
                            writer.WriteLine(string.Join(" ",line.Split().Reverse()));
                        }
                        row++;
                        line = reader.ReadLine();
                    }
                }
            }

        }
    }
}
