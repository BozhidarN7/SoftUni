using System;

namespace _2.CenterPoint
{
    class CenterPoint
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double firstPointDistance = Math.Sqrt(x1 * x1 + y1 * y1);
            double secondPointDistance = Math.Sqrt(x2 * x2 + y2 * y2);

            if (firstPointDistance <= secondPointDistance)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");

            }

        }
    }
}
