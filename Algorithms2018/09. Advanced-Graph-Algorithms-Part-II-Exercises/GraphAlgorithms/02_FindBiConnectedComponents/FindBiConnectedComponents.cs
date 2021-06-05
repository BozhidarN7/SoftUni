using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_FindBiConnectedComponents
{
    class FindBiConnectedComponents
    {
        static bool[] visited;
        static int[] depth;
        static int[] lowpoint;
        static int[] parent;
        static List<int>[] graph;
        static Stack<KeyValuePair<int, int>> biconnectedConnectedComponents;

        private static int count = 0;

        public static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine().Substring(7));
            int edges = int.Parse(Console.ReadLine().Substring(7));
            visited = new bool[nodes];
            depth = new int[nodes];
            lowpoint = new int[nodes];
            parent = new int[nodes];
            biconnectedConnectedComponents = new Stack<KeyValuePair<int, int>>();

            for (int i = 0; i < nodes; i++)
            {
                parent[i] = -1;
            }

            graph = new List<int>[nodes];
            for (int i = 0; i < nodes; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < edges; i++)
            {
                string[] edgeTokens = Console.ReadLine().Split();
                int parent = int.Parse(edgeTokens[0]);
                int child = int.Parse(edgeTokens[1]);

                graph[parent].Add(child);
                graph[child].Add(parent);
            }

            FindBiconnectedComponents(0, 1);

            Console.WriteLine($"Number of bi-connected components: {count}");
        }

        private static void FindBiconnectedComponents(int node, int d)
        {
            visited[node] = true;
            depth[node] = d;
            lowpoint[node] = d;

            foreach (var childNode in graph[node])
            {
                if (!visited[childNode])
                {
                    parent[childNode] = node;
                    FindBiconnectedComponents(childNode, d + 1);

                    biconnectedConnectedComponents.Push(new KeyValuePair<int, int>(node, childNode));
                    if (lowpoint[childNode] >= depth[node])
                    {
                        if (biconnectedConnectedComponents.Count > 0)
                        {
                            var edge = biconnectedConnectedComponents.Peek();
                            do
                            {
                                edge = biconnectedConnectedComponents.Pop();

                            } while (biconnectedConnectedComponents.Count > 0 && (edge.Key != node || edge.Value == biconnectedConnectedComponents.Peek().Key));

                            count++;
                        }
                    }

                    lowpoint[node] = Math.Min(lowpoint[node], lowpoint[childNode]);
                }
                else if (childNode != parent[node])
                {
                    lowpoint[node] = Math.Min(lowpoint[node], depth[childNode]);
                }
            }
        }
    }
}
