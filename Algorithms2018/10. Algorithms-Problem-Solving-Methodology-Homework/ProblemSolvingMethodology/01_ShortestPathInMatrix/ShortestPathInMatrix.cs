using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ShortestPathInMatrix
{
    class ShortestPathInMatrix
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            var graph = BuildGraph(matrix);
            var path = FindShortesPath(graph, 0, matrix.GetLength(0) * matrix.GetLength(1) - 1);

            var result = (from n in path
                          let row = n / matrix.GetLength(1)
                          let col = n % matrix.GetLength(1)
                          select matrix[row, col]).ToList();
            Console.WriteLine("Length: {0}", result.Sum());
            Console.WriteLine("Path: {0}", String.Join(" ", result));
        }

        private static List<int> FindShortesPath(int[,] graph, int sourceNode, int destinationNode)
        {
            int[] distance = new int[graph.GetLength(0)];
            int?[] previous = new int?[graph.GetLength(0)];
            bool[] used = new bool[graph.GetLength(0)];

            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = int.MaxValue;
            }
            distance[sourceNode] = 0;

            while (true)
            {
                int minDistance = int.MaxValue;
                int minNode = 0;
                for (int node = 0; node < graph.GetLength(0); node++)
                {
                    if (!used[node] && distance[node] < minDistance)
                    {
                        minDistance = distance[node];
                        minNode = node;
                    }
                }
                if (minDistance == int.MaxValue)
                {
                    break;
                }
                used[minNode] = true;

                for (int i = 0; i < graph.GetLength(0); i++)
                {
                    if (graph[minNode, i] != 0)
                    {
                        int newDistance = distance[minNode] + graph[minNode, i];
                        if (newDistance < distance[i])
                        {
                            distance[i] = newDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }

            if (distance[destinationNode] == int.MaxValue)
            {
                return null;
            }

            var path = new Stack<int>();
            int? currentNode = destinationNode;
            while (currentNode != null)
            {
                path.Push(currentNode.Value);
                currentNode = previous[currentNode.Value];
            }
            return path.ToList();
        }

        private static int[,] BuildGraph(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[] directions = { 0, -1, -1, 0, 0, 1, 1, 0 };
            var graph = new int[rows * cols, rows * cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    for (int k = 0; k < directions.Length; k += 2)
                    {
                        int childRow = row + directions[k];
                        int childCol = col + directions[k + 1];

                        if (childRow >= 0 && childRow < rows && childCol >= 0 && childCol < cols)
                        {
                            var parentNode = row * matrix.GetLength(1) + col;
                            var childNode = childRow * matrix.GetLength(1) + childCol;
                            graph[parentNode, childNode] = matrix[childRow, childCol];
                            graph[parentNode, parentNode] = 0;
                        }
                    }
                }
            }

            return graph;
        }

    }
}