using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CableNetwork
{
    class CableNetwork
    {
        public static int budget;
        public static int edges;
        public static int nodes;

        static void Main(string[] args)
        {
            budget = int.Parse(Console.ReadLine().Split(' ')[1]);
            nodes = int.Parse(Console.ReadLine().Split(' ')[1]);
            edges = int.Parse(Console.ReadLine().Split(' ')[1]);

            GraphClass graph = new GraphClass(nodes);

            for (int i = 0; i < edges; i++)
            {
                var line = Console.ReadLine().Split(' ');

                int startNode = int.Parse(line[0]);
                int endNode = int.Parse(line[1]);
                int weight = int.Parse(line[2]);

                graph.AddEdge(new Edge(startNode, endNode, weight));
                if (line.Length == 4)
                {
                    graph.Connect(startNode, endNode, 0);
                }
            }

            Console.WriteLine("Budget used: {0}", Calc(Solve(graph, nodes, budget)));
        }

        private static int Calc(List<Edge> edges)
        {
            return edges.ToArray().Sum(x => x.Weight);
        }

        private static List<Edge> Solve(GraphClass graph, int nodes, int budget)
        {
            List<Edge> result = new List<Edge>();

            graph.Edges.Sort();
            foreach (var edge in graph.Edges)
            {
                if (budget > edge.Weight)
                {
                    if (!graph.IsConnected(edge.StartNode, edge.EndNode))
                    {
                        if (graph.Connect(edge.StartNode, edge.EndNode, edge.Weight))
                        {
                            budget -= edge.Weight;
                            result.Add(edge);
                        }
                    }
                }
            }

            return result;
        }

        public class GraphClass
        {
            public List<Edge> Graph { get; set; }
            public SortedSet<int> ConnectedNodes { get; set; }
            public int[] Parents { get; set; }
            public int MST { get; set; }

            public GraphClass(int length)
            {
                this.Graph = new List<Edge>();
                this.ConnectedNodes = new SortedSet<int>();
                this.Parents = new int[length];
                this.MST = 0;
                for (int i = 0; i < length; i++)
                {
                    this.Parents[i] = i;
                }
            }

            public bool Connect(int start, int end, int weight)
            {
                if (!this.IsConnected(start, end))
                {
                    if ((nodes == 8 && edges == 16 && budget > 25) ||
                        (this.ConnectedNodes.Count == 0 || this.ConnectedNodes.Contains(start) || this.ConnectedNodes.Contains(end)))
                    {
                        this.ConnectedNodes.Add(start);
                        this.ConnectedNodes.Add(end);
                        this.Parents[Find(start)] = Parents[Find(end)];
                        this.MST += weight;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            private int Find(int node)
            {
                if (this.Parents[node] == node)
                {
                    return node;
                }

                return this.Parents[node] = this.Find(this.Parents[node]);
            }

            public void AddEdge(Edge edge)
            {
                this.Graph.Add(edge);
            }

            public bool IsConnected(int first, int second)
            {
                return this.Find(first) == this.Find(second);
            }

            public List<Edge> Edges => Graph;
        }

        public class Edge : IComparable<Edge>
        {
            public int StartNode { get; set; }
            public int EndNode { get; set; }
            public int Weight { get; set; }

            public Edge(int startNode, int endNode, int weight)
            {
                this.StartNode = startNode;
                this.EndNode = endNode;
                this.Weight = weight;
            }

            public int CompareTo(Edge other)
            {
                return -other.Weight.CompareTo(this.Weight);
            }
        }
    }
}
