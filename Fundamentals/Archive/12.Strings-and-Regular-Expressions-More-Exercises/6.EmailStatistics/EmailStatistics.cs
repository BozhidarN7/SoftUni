using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _6.EmailStatistics
{
    class EmailStatistics
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"^(?<user>[A-Za-z]{5,})\@(?<server>[a-z]{3,})(?<domain>(\.com)|(\.bg)|(\.org))$");
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, HashSet<string>> emails = new Dictionary<string, HashSet<string>>();

            for (int i = 0; i < n; i++)
            {
                Match match = pattern.Match(Console.ReadLine());
                if (match.Success)
                {
                    string domain = match.Groups["server"].Value + match.Groups["domain"].Value;
                    string user = match.Groups["user"].Value;

                    if (!emails.ContainsKey(domain))
                    {
                        emails.Add(domain, new HashSet<string>());
                    }
                    if (!emails[domain].Contains(user))
                    {
                        emails[domain].Add(user);
                    }
                }
            }
            foreach (var email in emails.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{email.Key}:");
                foreach (var user in email.Value)
                {
                    Console.WriteLine($"### {user}");
                }
            }

        }
    }
}
