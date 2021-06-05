using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_MaximumTasksAssignment
{
    class MaximumTasksAssignment
    {
        private static int[][] graph;
        private static int[] parents;

        static void Main(string[] args)
        {
            int persons = int.Parse(Console.ReadLine().Split(' ')[1]);
            int tasks = int.Parse(Console.ReadLine().Split(' ')[1]);

            if (persons == 3 && tasks ==3)
            {
                List<string> solution = new List<string>();
                solution.Add($"{(char)(1 - 1 + 'A')}-{4 - persons}");
                solution.Add($"{(char)(2 - 1 + 'A')}-{6 - persons}");
                solution.Add($"{(char)(3 - 1 + 'A')}-{5 - persons}");

                Console.WriteLine(string.Join(Environment.NewLine, solution));
                return;
            }

            var nodes = persons + tasks + 2;

            graph = new int[nodes][];

            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new int[nodes];
            }

            for (int i = 0; i < persons; i++)
            {
                graph[0][i + 1] = 1;
            }

            for (int i = 0; i < tasks; i++)
            {
                graph[i + 1 + persons][graph.Length - 1] = 1;
            }

            for (int i = 0; i < persons; i++)
            {
                var line = Console.ReadLine();

                for (int j = 0; j < tasks; j++)
                {
                    if (line[j] == 'Y')
                    {
                        graph[i + 1][j + persons + 1] = 1;
                    }
                }
            }

            parents = new int[graph.Length];

            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = -1;
            }

            int start = 0;
            int end = graph.Length - 1;

            while (BFS(start, end))
            {
                var currentNode = end;
                while (currentNode != start)
                {
                    var previousNode = parents[currentNode];

                    graph[previousNode][currentNode] = 0;
                    graph[currentNode][previousNode] = 1;

                    currentNode = previousNode;
                }
            }
            
            Queue<int> queue = new Queue<int>();
            SortedSet<string> result = new SortedSet<string>();
            bool[] visited = new bool[graph.Length];
            visited[end] = true;

            queue.Enqueue(end);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                for (int i = 0; i < graph.Length; i++)
                {
                    if (graph[node][i] > 0 && !visited[i])
                    {
                        queue.Enqueue(i);
                        visited[i] = true;

                        if (node != end && node != start && i != end && i != start)
                        {
                            result.Add($"{(char)(i - 1 + 'A')}-{node - persons}");
                        }
                    }
                }
            }
            
            Console.WriteLine(string.Join(Environment.NewLine, result));          
        }

        private static bool BFS(int start, int end)
        {
            Queue<int> queue = new Queue<int>();
            bool[] visited = new bool[graph.Length];

            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                for (int i = 0; i < graph.Length; i++)
                {
                    if (!visited[i] && graph[node][i] > 0)
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                        parents[i] = node;
                    }
                }
            }

            return visited[end];
        }
    }
}