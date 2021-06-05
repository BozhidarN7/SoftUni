using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Limber
{
    class Lumber
    {
        private static int count = 0;

        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            int numberOfLogs = int.Parse(input[0]);
            int numberOfQueries = int.Parse(input[1]);

            List<Log> logs = new List<Log>();
            List<int>[] graph = new List<int>[numberOfLogs + 1];

            for (int i = 1; i <= numberOfLogs; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Log log = new Log(i, line[0], line[1], line[2], line[3]);

                graph[i] = new List<int>();
                foreach (var element in logs)
                {
                    if (element.Intersect(log))
                    {
                        graph[element.Id].Add(i);
                        graph[i].Add(element.Id);
                    }
                }

                logs.Add(log);
            }


            bool[] visited = new bool[numberOfLogs + 1];
            int[] id = new int[numberOfLogs + 1];

            for (int i = 1; i <= numberOfLogs; i++)
            {
                if (!visited[i])
                {
                    DFS(i, visited, id, graph);
                    count++;
                }
            }

            for (int i = 0; i < numberOfQueries; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int from = line[0];
                int to = line[1];

                Console.WriteLine("{0}", id[from] == id[to] ? "YES" : "NO");
            }
        }

        private static void DFS(int vertex, bool[] visited, int[] id, List<int>[] graph)
        {
            visited[vertex] = true;
            id[vertex] = count;
            foreach (var child in graph[vertex])
            {
                if (!visited[child])
                {
                    DFS(child, visited, id, graph);
                }
            }
        }
    }

    public class Log
    {
        public int Id { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }

        public Log(int id, int x1, int y1, int x2, int y2)
        {
            this.Id = id;
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }

        public bool Intersect(Log other)
        {
            bool horizontalIntersection = this.X1 <= other.X2 && this.X2 >= other.X1;
            bool verticalIntersection = this.Y1 >= other.Y2 && this.Y2 <= other.Y1;

            return horizontalIntersection && verticalIntersection;
        }
    }
}
