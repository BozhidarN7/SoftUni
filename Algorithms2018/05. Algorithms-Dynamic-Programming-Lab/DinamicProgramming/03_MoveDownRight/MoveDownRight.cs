using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_MoveDownRight
{
    class MoveDownRight
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var numbers = new int[rows, cols];

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                var line = Console.ReadLine().Split(' ');

                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    numbers[i, j] = int.Parse(line[j]);
                }
            }

            var sums = new int[rows, cols];
            sums[0, 0] = numbers[0, 0];


            for (int row = 1; row < rows; row++)
            {
                sums[row, 0] = sums[row - 1, 0] + numbers[row, 0];
            }

            for (int col = 1; col < cols; col++)
            {
                sums[0, col] = sums[0, col - 1] + numbers[0, col];
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    var result = Math.Max(sums[row - 1, col], sums[row, col - 1]) + numbers[row, col];

                    sums[row, col] = result;
                }
            }

            var path = new List<string>();

            path.Add($"[{rows - 1}, {cols - 1}]");

            var currentRow = rows - 1;
            var currentCol = cols - 1;

            while (currentRow != 0 || currentCol != 0)
            {
                var top = -1;
                if (currentRow - 1 >= 0)
                {
                    top = sums[currentRow - 1, currentCol];
                }

                var left = -1;
                if (currentCol - 1 >= 0)
                {
                    left = sums[currentRow, currentCol - 1];
                }

                if (top > left)
                {
                    path.Add($"[{currentRow - 1}, {currentCol }]");
                    currentRow -= 1;
                }
                else
                {
                    path.Add($"[{currentRow}, {currentCol - 1 }]");
                    currentCol -= 1;
                }
            }
            path.Reverse();
            Console.WriteLine(string.Join(" ", path));
        }
    }
}
