using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Protoss
{
    class Protoss
    {
        private static int[][] graph;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            graph = new int[size][];

            for (int i = 0; i < size; i++)
            {
                graph[i] = new int[size];
            }

            for (int i = 0; i < size; i++)
            {
                var line = Console.ReadLine();

                for (int j = 0; j < size; j++)
                {
                    if (line[j] == 'Y')
                    {
                        graph[i][j] = 1;
                        graph[j][i] = 1;
                    }
                }
            }

            int max = 0;

            for (int i = 0; i < size; i++)
            {
                int currentMax = DFS(i);

                if (currentMax > max)
                {
                    max = currentMax;
                }
            }

            Console.WriteLine(max);
        }

        private static int DFS(int startNode)
        {
            int max = 0;

            bool[] visited = new bool[graph.Length];
            visited[startNode] = true;

            int[] parent = Enumerable.Repeat(-1, graph.Length).ToArray();

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                for (int child = 0; child < graph[node].Length; child++)
                {
                    if (graph[node][child] > 0 && !visited[child])
                    {
                        queue.Enqueue(child);
                        parent[child] = node;
                        visited[child] = true;

                        if (graph[startNode][child] > 0 || graph[startNode][parent[child]] > 0)
                        {
                            max++;
                        }
                    }
                }
            }

            return max;
        }
    }
}
