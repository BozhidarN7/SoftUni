using System;

namespace _2.Bee
{
    class Bee
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int row = 0;
            int col = 0;

            for (int i = 0; i < n; i++)
            {
                string rowData = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rowData[j];
                    if (matrix[i, j] == 'B')
                    {
                        row = i;
                        col = j;
                        matrix[row, col] = '.';
                    }
                }
            }
            int flowers = 0;
            bool gotLost = FlyThroughTheMatrix(matrix, row, col, ref flowers, n);

            if (gotLost)
            {
                Console.WriteLine("The bee got lost!");
            }
            if (flowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            }
            PrintMatrix(matrix, n);
        }

        private static void PrintMatrix(char[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static bool FlyThroughTheMatrix(char[,] matrix, int row, int col, ref int flowers, int n)
        {
            bool gotLost = false;

            string direction = Console.ReadLine();
            while (direction !="End")
            {
                Fly(ref row, ref col, direction);

                if (!IsInBounds(row, col, n))
                {
                    gotLost = true;
                    break;
                }

                if (matrix[row, col] == 'f')
                {
                    flowers++;
                }


                if (matrix[row, col] == 'O')
                {
                    matrix[row, col] = '.';
                    Fly(ref row, ref col, direction);
                    if (matrix[row, col] == 'f')
                    {
                        flowers++;
                    }

                }
                matrix[row, col] = '.';
                direction = Console.ReadLine();
            }
            if (!gotLost)
            {
                matrix[row, col] = 'B';
            }
            return gotLost;
        }

        private static void Fly(ref int row, ref int col, string direction)
        {
            if (direction == "up") row--;
            if (direction == "down") row++;
            if (direction == "right") col++;
            if (direction == "left") col--;
        }

        private static bool IsInBounds(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
