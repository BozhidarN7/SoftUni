using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.Race
{
    class Race
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            string[] names = Console.ReadLine().Split(", ").ToArray();
            for (int i = 0; i < names.Length; i++)
            {
                dic.Add(names[i], 0);
            }

            string input = Console.ReadLine();
            while (input  != "end of race")
            {
                Regex pattern = new Regex(@"[A-Za-z]");
                MatchCollection matches = pattern.Matches(input);
                string name = string.Join("", matches);

                pattern = new Regex(@"\d");
                matches = pattern.Matches(input);
                int distance = matches.Cast<Match>().Select(x => int.Parse(x.Value)).ToArray().Sum();

                if (dic.ContainsKey(name))
                {
                    dic[name] += distance;
                }

                input = Console.ReadLine();
            }

            dic = dic.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine($"1st place: {dic.Keys.ElementAt(0)}");
            Console.WriteLine($"2nd place: {dic.Keys.ElementAt(1)}");
            Console.WriteLine($"3rd place: {dic.Keys.ElementAt(2)}");
        }
    }
}
