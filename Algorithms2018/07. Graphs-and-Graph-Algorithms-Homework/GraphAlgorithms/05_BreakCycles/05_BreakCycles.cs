using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_BreakCycles
{
    class _05_BreakCycles
    {
        private static SortedDictionary<string, List<string>> graph = new SortedDictionary<string, List<string>>();

        static void Main(string[] args)
        {
            while (true)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                var tokens = line.Split(' ');
                var node = tokens[0];
                var otherNodes = tokens.Skip(2).ToArray();

                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<string>();
                }

               graph[node].AddRange(otherNodes.Select(n => n));
            }

            List<string> result = new List<string>();

            foreach (var node in graph)
            {
                string start = node.Key;

                foreach (var end in graph[start].OrderBy(x => x))
                {
                    graph[start].Remove(end);
                    graph[end].Remove(start);
                    if (HasPath(start,end))
                    {
                        result.Add($"{start} - {end}");
                    }
                    else
                    {
                        graph[start].Add(end);
                        graph[end].Add(start);
                    }
                }
            }

            Console.WriteLine($"Edges to remove: {result.Count}");
            result.ForEach(x => Console.WriteLine(x));
        }

        public static bool HasPath(string startVertex, string endVertex)
        {
            Queue<string> queue = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();

            queue.Enqueue(startVertex);
            visited.Add(startVertex);

            while (queue.Count > 0)
            {
                string node = queue.Dequeue();

                foreach (var child in graph[node].OrderBy(x => x))
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);

                        if (child == endVertex)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }  
}
