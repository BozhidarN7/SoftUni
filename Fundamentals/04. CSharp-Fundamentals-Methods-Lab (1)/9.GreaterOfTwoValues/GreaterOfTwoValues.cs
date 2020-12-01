using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greater_of_Two_Values
{
    class Greater_of_Two_Values
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            if (input == "int")
            {
                int first = int.Parse(Console.ReadLine());
                int second = int.Parse(Console.ReadLine());
                int outputLarger = GetIntMax(first, second);
                Console.WriteLine(outputLarger);
            }
            else if (input == "char")
            {
                char first = char.Parse(Console.ReadLine());
                char second = char.Parse(Console.ReadLine());
                char outputLarger = GetCharMax(first, second);
                Console.WriteLine(outputLarger);
            }
            else
            {
                string first = Console.ReadLine();
                string second = Console.ReadLine();
                string outputLarger = GetStringMax(first, second);
                Console.WriteLine(outputLarger);
            }
        }

        static int GetIntMax(int first, int second)
        {
            int larger = 0;
            if (first >= second) larger = first;
            else larger = second;
            return larger;
        }

        static char GetCharMax(char first, char second)
        {
            char larger = (char)0x00;
            if (first >= second) larger = first;
            else larger = second;
            return larger;
        }

        static string GetStringMax(string first, string second)
        {
            string larger = string.Empty;
            if (first.CompareTo(second) >= 0) larger = first;
            else larger = second;
            return larger;
        }
    }
}