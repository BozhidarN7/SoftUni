using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Salaries
{
    class _04_Salaries
    {
        private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        private static Dictionary<int, long> salaries = new Dictionary<int, long>();

        static void Main(string[] args)
        {
            int numberOfEmployees = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string employee = Console.ReadLine();

                graph.Add(i, new List<int>());

                for (int j = 0; j < employee.Length; j++)
                {
                    if (employee[j] == 'Y')
                    {
                        graph[i].Add(j);
                    }
                }
            }

            var orderedByManagers = graph.OrderBy(x => x.Value.Count).ToDictionary(x => x.Key, y => y.Value);

            foreach (var employee in orderedByManagers)
            {
                DFS(orderedByManagers, employee.Key, new bool[graph.Count]);
            }

            long totalSalarySum = salaries.Values.Sum();
            Console.WriteLine(totalSalarySum);
        }

        private static void DFS(Dictionary<int, List<int>> employeeGraph, int manager, bool[] visited)
        {
            if (salaries.ContainsKey(manager) && salaries[manager] != 0)
            {
                return;
            }

            if (!visited[manager])
            {
                visited[manager] = true;

                if (employeeGraph[manager].Count == 0)
                {
                    salaries.Add(manager, 1);
                    return;
                }

                if (!salaries.ContainsKey(manager))
                {
                    salaries.Add(manager, 0);
                }

                foreach (var employee in employeeGraph[manager])
                {
                    if (visited[employee] == false)
                    {
                        DFS(employeeGraph, employee, visited);
                    }

                    salaries[manager] += salaries[employee];
                }
            }
        }
    }
}
