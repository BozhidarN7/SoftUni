using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4.SantasSecretHelper
{
    class SantasSecretHelper
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            string message = Console.ReadLine();
            Regex pattern = new Regex(@"@(?<name>[A-Za-z]+)[^@\-!:>]*(?<behaviour>![GN]!)");
            while (message != "end")
            {
                string decoded = new string(message.Select(x => x = (char)((int)x - key)).ToArray());
                Match match = pattern.Match(decoded);
                if (match.Groups["behaviour"].Value == "!G!")
                {
                    Console.WriteLine(match.Groups["name"].Value);
                }
                message = Console.ReadLine();
            }
        }
    }
}
