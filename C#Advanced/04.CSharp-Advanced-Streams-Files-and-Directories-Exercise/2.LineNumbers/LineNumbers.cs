using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"../../../../text.txt");
            using (StreamWriter writer = File.AppendText(@"../../../../output.txt"))
            {
                int lineNumber = 1;
                foreach (string line in lines)
                {
                    int punctuationMarksCount = Regex.Matches(line, @"[^\w\s]").Count;
                    int letters = Regex.Matches(line, @"[a-zA-Z]").Count;
                    writer.WriteLine($"Line {lineNumber}: {line}({letters})({punctuationMarksCount})");
                    lineNumber++;
                }
            }
        }
    }
}
