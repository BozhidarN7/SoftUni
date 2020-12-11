using System;
using System.Text.RegularExpressions;

namespace _8.UseYourChainsBuddy
{
    class UseYourChainsBuddy
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex(@"(<p>)(?<value>.*?)(<\/p>)");
            MatchCollection matches = pattern.Matches(input);

            string result = "";
            foreach (Match match in matches)
            {
                string text = Regex.Replace(match.Groups["value"].Value, @"[^a-z0-9]+", " ");
                text = Regex.Replace(text, @"\s+", " ");
                char[] letters = text.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i] >= 'a' && letters[i] <= 'm')
                    {
                        letters[i] = (char)((int)letters[i] + 13);
                    }
                    else if (letters[i] >= 'n' && letters[i] <= 'z')
                    {
                        letters[i] = (char)((int)letters[i] - 13);
                    }
                }
                result += new string(letters);
            }
            Console.WriteLine(result);
        }
    }
}

