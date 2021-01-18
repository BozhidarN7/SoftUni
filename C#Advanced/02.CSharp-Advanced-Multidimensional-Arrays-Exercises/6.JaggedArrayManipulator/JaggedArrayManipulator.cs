using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    class JaggedArrayManipulator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] matrix = new double[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            }

            for (int i = 0; i < n - 1; i++)
            {
                if (matrix[i].Length == matrix[i + 1].Length)
                {
                    matrix[i] = matrix[i].Select(x => x * 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[i] = matrix[i].Select(x => x / 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x / 2).ToArray();
                }
            }

            string command = Console.ReadLine();
            while(command != "End")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);

                if (row >=0 && row < n && col >= 0 && col < matrix[row].Length)
                {
                    if (tokens[0] == "Add")
                    {
                        matrix[row][col] += value;
                    }
                    else if(tokens[0] == "Subtract")
                    {
                        matrix[row][col] -= value;
                    }
                }
                command = Console.ReadLine();
            }
            foreach(double[] row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
