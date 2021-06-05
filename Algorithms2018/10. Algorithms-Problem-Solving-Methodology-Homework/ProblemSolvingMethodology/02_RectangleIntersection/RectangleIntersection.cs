using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_RectangleIntersection
{
    class RectangleIntersection
    {
        private static int totalArea = 0;

        static void Main(string[] args)
        {
            int numberOfRectangles = int.Parse(Console.ReadLine());

            List<Rectangle> Rectangles = new List<Rectangle>();

            for (int i = 1; i <= numberOfRectangles; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Rectangle rectangle = new Rectangle(line[0], line[3], line[1], line[2]);

                foreach (var element in Rectangles)
                {
                    if (element.Intersect(rectangle))
                    {
                        CalculateIntersectArea(element, rectangle);
                    }
                }

                Rectangles.Add(rectangle);
            }

            Console.WriteLine(totalArea);
        }

        private static void CalculateIntersectArea(Rectangle rect1, Rectangle rect2)
        {
            int horizontalOverlap = Math.Abs(Math.Abs(rect1.X2) - Math.Abs(rect2.X1));
            int verticalOverlap = Math.Abs(Math.Abs(rect1.Y1) - Math.Abs(rect2.Y2));
            int overlapArea = horizontalOverlap * verticalOverlap;
            totalArea += overlapArea;
        }
    }

    public class Rectangle
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public int Right { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Bottom { get; set; }

        public Rectangle(int x1, int y1, int x2, int y2)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
            this.Right = x1 + x2;
            this.Left = x1;
            this.Top = y1;
            this.Bottom = y1 + y2;
        }

        public bool Intersect(Rectangle other)
        {
            bool horizontalIntersection = this.X1 <= other.X2 && this.X2 >= other.X1;
            bool verticalIntersection = this.Y1 >= other.Y2 && this.Y2 <= other.Y1;

            return horizontalIntersection && verticalIntersection;
        }

    }
}
