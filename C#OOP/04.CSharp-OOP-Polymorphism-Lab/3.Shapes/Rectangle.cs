using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }
        public double Height
        {
            get => height;
            set
            {
                height = value;
            }
        }
        public double Width
        {
            get => width;
            set
            {
                width = value;
            }
        }
        public override double CalculatePerimeter()
        {
            return (width + height) * 2;
        }

        public override double CalculateArea()
        {
            return width * height;
        }
        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }
}
