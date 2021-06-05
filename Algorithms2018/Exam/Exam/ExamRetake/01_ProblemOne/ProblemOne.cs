using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _01_ProblemOne
{
    class ProblemOne
    {
        private static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        private static BigInteger[] sums;
        private static BigInteger totalSum = 0;

        static void Main(string[] args)
        {
            int partisipants = int.Parse(Console.ReadLine());

            for (int i = 0; i < partisipants; i++)
            {
                graph.Add(i, new List<int>());
            }

            sums = new BigInteger[partisipants];

            for (int i = 0; i < partisipants; i++)
            {
                var line = Console.ReadLine();

                for (int j = 0; j < partisipants; j++)
                {
                    if (line[j] == 'R')
                    {
                        graph[i].Add(j);
                    }
                }
            }

            foreach (var node in graph)
            {
                BigInteger currentSum = DFS(node.Key, new HashSet<int>());
                totalSum += currentSum;
            }

            Console.WriteLine($"${totalSum:F2}");
        }

        private static BigInteger DFS(int node, HashSet<int> visited)
        {
            if (sums[node] > 0)
            {
                return sums[node];
            }

            BigInteger currentSum = 0;
            int childCount = 0;
            if (!visited.Contains(node))
            {
                visited.Add(node);

                foreach (var child in graph[node])
                {
                    currentSum += DFS(child, visited);
                    childCount++;
                }
            }

            currentSum *= childCount;

            if (currentSum == 0)
            {
                currentSum = 1;
            }

            sums[node] = currentSum;

            return sums[node];
        }
    }
}
