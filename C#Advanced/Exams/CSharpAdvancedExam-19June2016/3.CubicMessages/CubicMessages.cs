using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3.CubicMessages
{
    class CubicMessages
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if(input == "Over!")
                {
                    break;
                }

                int length = int.Parse(Console.ReadLine());
                Regex regex = new Regex($@"^(?<digits>\d+)(?<message>[A-Za-z]{{{length}}})(?<after>[^A-Za-z]*)$");

                Match match = regex.Match(input);

                if (!match.Success)
                {
                    continue;
                }

                string message = match.Groups["message"].Value;
                string digitsBefore = match.Groups["digits"].Value;
                string digitsAfter = string.Join("", match.Groups["after"].Value.Where(x => char.IsDigit(x)));

                string decrypted = "";
                for (int i = 0; i < digitsBefore.Length; i++)
                {
                    int digit = digitsBefore[i] - '0';
                    if (digit >=0 && digit < message.Length)
                    {
                        decrypted += message[digit];
                    }
                    else
                    {
                        decrypted += " ";
                    }
                           
                }

                for (int i = 0; i < digitsAfter.Length; i++)
                {
                    int digit = digitsAfter[i] - '0';
                    if (digit >= 0 && digit < message.Length)
                    {
                        decrypted += message[digit];
                    }
                    else
                    {
                        decrypted += " ";
                    }

                }

                Console.WriteLine($"{message} == {decrypted}");
            }
        }
    }
}
