using System;
using System.Linq;

namespace _6.JaggedArrayModification
{
    class JaggedArrayModification
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] matrix = new int[n][];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split();
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (row < 0 || row >= n || col < 0 || col >= matrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    command = Console.ReadLine();
                    continue;
                }
                if (tokens[0] == "Add")
                {
                    matrix[row][col] += value;
                }
                else if (tokens[0] == "Subtract")
                {
                    matrix[row][col] -= value;
                }
                command = Console.ReadLine();
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
