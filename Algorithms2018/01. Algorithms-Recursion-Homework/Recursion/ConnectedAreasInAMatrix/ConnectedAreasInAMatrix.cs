using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedAreasInAMatrix
{
    class ConnectedAreasInAMatrix
    {
        private static SortedSet<Area> areas = new SortedSet<Area>();

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    FindConnectedArea(matrix, row, col);
                }
            }

            Console.WriteLine($"Total areas found: {areas.Count}");
            int numberOfArea = 1;
            foreach (var item in areas)
            {
                Console.WriteLine($"Area #{numberOfArea++} at ({item.Row}, {item.Col}), size: {item.Size}");
            }

        }

        private static void FindConnectedArea(char[,] matrix, int row, int col)
        {
            if (matrix[row, col] == '*' || matrix[row, col] == 'v')
            {
                return;
            }

            Area area = new Area(row, col);
            FillArea(matrix, row, col, area);

            areas.Add(area);
        }

        private static void FillArea(char[,] matrix, int row, int col, Area area)
        {
            if (!IsInBounders(matrix,row,col)
                || matrix[row, col] == '*'
                || matrix[row, col] == 'v')
            {
                return;
            }

            matrix[row, col] = 'v';
            area.Size++;

            FillArea(matrix, row, col + 1, area);
            FillArea(matrix, row, col - 1, area);
            FillArea(matrix, row + 1, col, area);
            FillArea(matrix, row - 1, col, area);

        }

        private static bool IsInBounders(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
            col >= 0 && col < matrix.GetLength(1);
        }
    }

    class Area : IComparable<Area>
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }

        public Area(int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.Size = 0;
        }

        public int CompareTo(Area other)
        {
            int compare = other.Size.CompareTo(this.Size);

            if (compare == 0)
            {
                compare = this.Row.CompareTo(other.Row);
            }

            if (compare == 0)
            {
                compare = this.Col.CompareTo(other.Col);
            }

            return compare;
        }
    }
}
