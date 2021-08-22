using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char wallSymbol = '\u25A0';
        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            InitializeWallBorders();
        }

        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.TopY);

            SetVerticalLine(0);
            SetVerticalLine(this.LeftX - 1);
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < LeftX; leftX++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }
        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < TopY; topY++)
            {
                this.Draw(leftX, topY, wallSymbol);
            }
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.TopY == 0 || snake.LeftX == 0 || snake.LeftX == LeftX - 1 || snake.TopY == TopY;
        }
    }
}
