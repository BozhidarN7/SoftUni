using System;

namespace _7.PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[n][];
            pascalTriangle[0] = new long[] { 1 };
            for (int i = 1; i < n; i++)
            {
                pascalTriangle[i] = new long[pascalTriangle[i - 1].Length + 1];
                pascalTriangle[i][0] = 1;
                pascalTriangle[i][pascalTriangle[i].Length - 1] = 1;

                for (int j = 1; j < pascalTriangle[i].Length - 1; j++)
                {
                    pascalTriangle[i][j] = pascalTriangle[i - 1][j] + pascalTriangle[i - 1][j - 1];
                }
            }
            foreach(var row in pascalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
