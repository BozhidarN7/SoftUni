using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private Queue<Point> snakeElements;
        private List<Food> food;
        private Wall wall;

        public Snake(Wall wall)
        {
            snakeElements = new Queue<Point>();
            food = new List<Food>(3);
            this.wall = wall;
        }

        private void CreateSnake()
        {
            for (int topY = 1; topY <= 6; topY++)
            {
                snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void GetFoods()
        {
            food[0] = new FoodHash(wall);
            food[1] = new FoodDollar(wall);
            food[2] = new FoodAsterisk(wall);
        }

        private void GetNextPoint(Point direction,Point snakeHead)
        {
            
        }
    }
}
