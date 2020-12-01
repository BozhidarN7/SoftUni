using System;

namespace _6.CalculateRectangleArea
{
    class CalculateRectangleArea
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int area = FindArea(width, height);
            Console.WriteLine(area);
        }

        private static int FindArea(int width, int height)
        {
            return width * height;
        }
    }
}
