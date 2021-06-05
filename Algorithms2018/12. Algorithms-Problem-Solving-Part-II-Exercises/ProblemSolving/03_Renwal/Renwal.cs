using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Renwal
{
    class Renwal
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            List<string> paths = new List<string>();
            List<string> builds = new List<string>();
            List<string> destroy = new List<string>();

            for (int i = 0; i < size; i++)
            {
                paths.Add(Console.ReadLine());
            }
            for (int i = 0; i < size; i++)
            {
                builds.Add(Console.ReadLine());
            }
            for (int i = 0; i < size; i++)
            {
                destroy.Add(Console.ReadLine());
            }


            Console.WriteLine(GetCost(paths, builds, destroy));
        }

        private static int GetCost(List<string> paths, List<string> builds, List<string> destroy)
        {
            int size = paths.Count;
            int massiveCost = 0;
            int mstCost = 0;

            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (paths[i][j] == '0')
                    {
                        edges.Add(new Edge(i, j, GetValue(builds[i][j])));
                    }
                    else
                    {
                        int val = GetValue(destroy[i][j]);
                        edges.Add(new Edge(i, j, -val));
                        massiveCost += val;
                    }
                }
            }

            edges.Sort();

            int[] color = new int[size];
            for (int i = 0; i < size; i++)
            {
                color[i] = i;
            }

            for (int i = 0; i < edges.Count; i++)
            {
                Edge current = edges[i];

                if (color[current.Row] != color[current.Col])
                {
                    mstCost += current.Cost;

                    int oldColor = color[current.Col];
                    for (int j = 0; j < size; j++)
                    {
                        if (color[j] == oldColor)
                        {
                            color[j] = color[current.Row];
                        }
                    }
                }
            }

            return massiveCost + mstCost;
        }

        private static int GetValue(char c)
        {
            if (c >= 'A' && c <= 'Z')
            {
                return c - 'A';
            }
            return c - 'a' + 26;
        }
    }

    public class Edge : IComparable<Edge>
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Cost { get; set; }

        public Edge(int a, int b, int cost)
        {
            this.Row = a;
            this.Col = b;
            this.Cost = cost;
        }

        public int CompareTo(Edge other)
        {
            return this.Cost - other.Cost;
        }
    }
}
