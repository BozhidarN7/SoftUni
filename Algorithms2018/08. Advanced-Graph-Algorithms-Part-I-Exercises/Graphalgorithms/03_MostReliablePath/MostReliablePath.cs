using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_MostReliablePath
{
    class MostReliablePath
    {
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine().Split(' ')[1]);

            string[] path = Console.ReadLine().Split(' ');
            int start = int.Parse(path[1]);
            int end = int.Parse(path[3]);

            int edges = int.Parse(Console.ReadLine().Split(' ')[1]);

            List<KeyValuePair<int, double>>[] graph = new List<KeyValuePair<int, double>>[edges];
            graph = graph.Select(x => new List<KeyValuePair<int, double>>()).ToArray();

            for (int i = 0; i < edges; i++)
            {
                var line = Console.ReadLine().Split(' ');

                int startNode = int.Parse(line[0]);
                int endNode = int.Parse(line[1]);
                int weight = int.Parse(line[2]);

                graph[startNode].Add(new KeyValuePair<int, double>(endNode, Convert.ToDouble(weight) / 100));
                graph[endNode].Add(new KeyValuePair<int, double>(startNode, Convert.ToDouble(weight) / 100));
            }

            Console.WriteLine("Most reliable path reliability: {0:f2}%", FindMostReliablePath(graph, start, end).Key * 100);
            var result = FindMostReliablePath(graph, start, end).Value;
            Console.WriteLine(string.Join(" -> ", result));
        }

        private static KeyValuePair<double, List<int>> FindMostReliablePath(List<KeyValuePair<int, double>>[] graph, int start, int end)
        {
            double[] distances = new double[graph.Length];
            int[] parents = new int[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                distances[i] = 0;
                parents[i] = i;
            }

            SortedSet<Pair> queue = new SortedSet<Pair>();
            distances[start] = 1;
            for (int i = 0; i < graph.Length; i++)
            {
                queue.Add(new Pair(distances[i], i));
            }

            while (queue.Count > 0)
            {
                var vertex = queue.Min();
                queue.Remove(vertex);

                foreach (var item in graph[vertex.Value])
                {
                    if (distances[item.Key] < distances[vertex.Value] * item.Value)
                    {
                        queue.Remove(new Pair(distances[item.Key], item.Key));
                        distances[item.Key] = distances[vertex.Value] * item.Value;
                        queue.Add(new Pair(distances[item.Key], item.Key));
                        parents[item.Key] = vertex.Value;
                    }
                }
            }

            if (parents[end] == end)
            {
                return new KeyValuePair<double, List<int>>();
            }

            List<int> path = new List<int>();

            int node = end;
            while (node != start)
            {
                path.Add(node);
                node = parents[node];
            }
            path.Add(start);
            path.Reverse();

            return new KeyValuePair<double, List<int>>(distances[end], path);
        }
    }

    public class Pair : IComparable<Pair>
    {
        public double Key { get; set; }
        public int Value { get; set; }

        public Pair(double key, int value)
        {
            this.Key = key;
            this.Value = value;
        }

        public int CompareTo(Pair other)
        {
            return this.Key.CompareTo(other.Key);
        }
    }
}