using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_CyclesInGraph
{
    class CyclesInGraph
    {
        private static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private static Dictionary<string, bool> used = new Dictionary<string, bool>();
        private static Dictionary<string, bool> marked = new Dictionary<string, bool>();

        private static bool result;

        static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                var tokens = line.Split('–');

                if (!graph.ContainsKey(tokens[0]))
                {
                    graph.Add(tokens[0], new List<string>());
                }
                if (!graph.ContainsKey(tokens[1]))
                {
                    graph.Add(tokens[1], new List<string>());
                }
                if (!used.ContainsKey(tokens[0]))
                {
                    used.Add(tokens[0], false);
                    marked.Add(tokens[0], false);
                }
                if (!used.ContainsKey(tokens[1]))
                {
                    used.Add(tokens[1], false);
                    marked.Add(tokens[1], false);
                }

                graph[tokens[0]].Add(tokens[1]);
                graph[tokens[1]].Add(tokens[0]);
            }

            foreach (var item in graph)
            {
                if (!used[item.Key])
                {
                    DFS(item.Key);
                }
            }

            Console.WriteLine("Acyclic: {0}", result ? "No" : "Yes");
        }

        private static void DFS(string vertex, string previous = "")
        {
            used[vertex] = true;
            marked[vertex] = true;

            foreach (var item in graph[vertex])
            {
                if (item != previous)
                {
                    if (marked[item])
                    {
                        result = true;
                    }
                    if (!used[item])
                    {
                        DFS(item, vertex);
                    }
                }
            }
            marked[vertex] = false;
        }
    }
}
