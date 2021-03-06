using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(2, 5);
            Console.WriteLine(rectangle.Draw());
            Console.WriteLine(rectangle.CalculateArea());
        }
    }
}
