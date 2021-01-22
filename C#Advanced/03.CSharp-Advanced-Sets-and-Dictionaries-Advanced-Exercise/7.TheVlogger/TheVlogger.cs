using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.TheVlogger
{
    class TheVlogger
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> vloggers = new Dictionary<string, HashSet<string>>();
            Dictionary<string, int> vloggersAndFollowres = new Dictionary<string, int>();
            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] tokens = input.Split();

                if (tokens[1] == "joined")
                {
                    if (!vloggers.ContainsKey(tokens[0]))
                    {
                        vloggers.Add(tokens[0], new HashSet<string>());
                        vloggersAndFollowres.Add(tokens[0], 0);
                    }
                }
                else
                {
                    if (vloggers.ContainsKey(tokens[0]) && vloggers.ContainsKey(tokens[2]) && tokens[0] != tokens[2]
                        && !vloggers[tokens[0]].Contains(tokens[2]))
                    {
                        vloggers[tokens[0]].Add(tokens[2]);
                        vloggersAndFollowres[tokens[2]]++;
                    }
                }
                input = Console.ReadLine();
            }
            int count = 1;
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            foreach ((string vlogger, int followers) in vloggersAndFollowres.OrderByDescending(x => x.Value).ThenBy(x => vloggers[x.Key].Count))
            {
                if (count == 1)
                {
                    Console.WriteLine($"{count++}. {vlogger} : {followers} followers, {vloggers[vlogger].Count} following");
                    foreach (var pair in vloggers.OrderBy(x => x.Key))
                    {
                        if (pair.Value.Contains(vlogger))
                            Console.WriteLine($"*  {pair.Key}");
                    }
                }
                else
                {
                    Console.WriteLine($"{count++}. {vlogger} : {followers} followers, {vloggers[vlogger].Count} following");
                }
            }

        }
    }
}
