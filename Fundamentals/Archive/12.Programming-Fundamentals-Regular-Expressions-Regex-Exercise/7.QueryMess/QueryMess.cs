using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _7.QueryMess
{
    class QueryMess
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"(?<key>[^?&]+)=(?<value>[^?&]+)");
            string input = Console.ReadLine();
            while (input != "END")
            {
                MatchCollection matches = pattern.Matches(input);
                Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
                foreach (Match match in matches)
                {
                    string key = match.Groups["key"].Value;
                    string value = match.Groups["value"].Value;

                    Regex whiteSpacesPattern = new Regex(@"(%20|\+)+");
                    key = whiteSpacesPattern.Replace(key, " ").Trim();
                    value = whiteSpacesPattern.Replace(value, " ").Trim();
                    if (!result.ContainsKey(key))
                    {
                        result.Add(key, new List<string>());
                    }
                    result[key].Add(value);
                }

                foreach (var item in result)
                {
                    Console.Write($"{item.Key}=[{string.Join(", ", item.Value)}]");
                }
                Console.WriteLine();
                input = Console.ReadLine();
            }
        }
    }
}
