using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_DistanceBetweenVertices
{
    public class DistanceBetweenVertices
    {
        private static int distance = int.MaxValue;

        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine();
            var secondLine = Console.ReadLine();

            var graph = new Dictionary<int, List<int>>();

            for(int i = 0; i < int.Parse(firstLine); i++)
            {
                var line = Console.ReadLine();
                var data = line.Split(new char[] { ':',' ' });
                var key = int.Parse(data[0]);

                if (!graph.ContainsKey(key))
                {
                    graph.Add(key, new List<int>());
                }

                for (int j = 1; j < data.Count(); j++)
                {
                    if (data[j] != string.Empty)
                    {
                        graph[key].Add(int.Parse(data[j]));
                    }
                }
            }

            for(int i = 0; i < int.Parse(secondLine); i++)
            {
                var line = Console.ReadLine();
                var data = line.Split('-');
                var start = int.Parse(data[0]);
                var end = int.Parse(data[1]);

                DFS(graph, start, end, new List<int>(), new List<int>());

                if (distance == int.MaxValue)
                {
                    Console.WriteLine("{{{0}, {1}}} -> {2}", start, end, -1);
                }
                else
                {
                    Console.WriteLine("{{{0}, {1}}} -> {2}", start, end, distance);
                    distance = int.MaxValue;
                }
            }
        }

        private static void DFS(Dictionary<int, List<int>> graph, int start, int end, List<int> visited, List<int> path)
        {
            if (start == end)
            {
                if (distance > path.Count)
                {
                    distance = path.Count;
                }

                return;
            }

            if (!visited.Contains(start))
            {
                visited.Add(start);
                foreach (var node in graph[start])
                {
                    if (!visited.Contains(node))
                    {
                        path.Add(node);
                        DFS(graph, node, end, visited, path);
                        path.Remove(node);
                        visited.Remove(node);
                    }
                }
            }
        }
    }
}