using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
            }
        }

        public override double CalculateArea()
        {
            return radius * radius * Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return 2 * radius * Math.PI;
        }

        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }
}
