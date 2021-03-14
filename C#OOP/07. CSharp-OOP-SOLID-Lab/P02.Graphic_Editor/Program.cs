using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor ge = new GraphicEditor();

            Circle circle = new Circle();
            ge.DrawShape(circle);

            Rectangle rectangle = new Rectangle();
            ge.DrawShape(rectangle);

            IShape squareShape = new Square();
            ge.DrawShape(squareShape);
        }
    }
}
