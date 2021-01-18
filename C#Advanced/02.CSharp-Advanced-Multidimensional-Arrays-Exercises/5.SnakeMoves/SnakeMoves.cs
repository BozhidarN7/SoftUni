using System;
using System.Linq;

namespace _5.SnakeMoves
{
    class SnakeMoves
    {
        static void Main(string[] args)
        {
            int[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = tokens[0];
            int cols = tokens[1];

            string snake = Console.ReadLine();
            char[,] matrix = new char[rows, cols];
            string direction = "right";
            int row = 0;
            int col = 0;
            int snakeIndex = 0;
            for (int i = 0; i < rows * cols; i++)
            {
                if (direction == "right")
                {
                    matrix[row, col] = snake[snakeIndex++];
                    col++;
                }
                else if (direction == "left")
                {
                    matrix[row, col] = snake[snakeIndex++];
                    col--;
                }

                if (col == cols)
                {
                    col--;
                    row++;
                    direction = "left";
                }
                if (col == -1)
                {
                    col++;
                    row++;
                    direction = "right";
                }

                if (snakeIndex == snake.Length)
                {
                    snakeIndex = 0;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}
