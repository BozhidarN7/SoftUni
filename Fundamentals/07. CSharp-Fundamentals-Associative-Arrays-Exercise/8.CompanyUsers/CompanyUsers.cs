using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.CompanyUsers
{
    class CompanyUsers
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> companies = new Dictionary<string, HashSet<string>>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                if (!companies.ContainsKey(tokens[0]))
                {
                    companies.Add(tokens[0], new HashSet<string>());
                }
                companies[tokens[0]].Add(tokens[1]);

                input = Console.ReadLine();
            }

            foreach (var company in companies.OrderBy(x => x.Key))
            {
                Console.WriteLine(company.Key);
                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
