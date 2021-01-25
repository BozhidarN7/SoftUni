using System;
using System.IO;

namespace _2.LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter(@"../../../../Resources/02.LineNumbers/output.txt")) // use your path
            {
                int lineNumber = 1;
                using (StreamReader reader = new StreamReader(@"../../../../Resources/02.LineNumbers/input.txt")) // use your path
                {
                    string line = reader.ReadLine();
                    while(line != null)
                    {
                        writer.WriteLine($"{lineNumber}. {line}");
                        line = reader.ReadLine();
                        lineNumber++;
                    }
                }
            }
        }
    }
}
