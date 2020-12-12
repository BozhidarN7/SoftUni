using System;
using System.Text;

namespace _3.KarateStrings
{
    class KarateStrings
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder result = new StringBuilder();
            int totalStrength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '>')
                {
                    result.Append(input[i]);
                    continue;
                }
                totalStrength += (input[i + 1] -'0');
                result.Append(input[i]);
                while (totalStrength > 0 && i < input.Length)
                {
                    i++;
                    if (i < input.Length && input[i] == '>')
                    {
                        i--;
                        break;
                    }
                    totalStrength--;
                }
            }
            Console.WriteLine(result.ToString());
        }
    }
}
