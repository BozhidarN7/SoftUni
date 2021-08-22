using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Point[] pointsOfDirection;
        Direction direction;
        Snake snake;
        Wall wall;
        double sleepTime;
   
        public Engine(Wall wall, Snake snake)
        {
            pointsOfDirection = new Point[4];
            this.wall = wall;
            this.snake = snake;
            sleepTime = 100;

        }

        public void Run()
        {
            CreateDirections();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = snake.isMoving(pointsOfDirection[(int)direction]);

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }
        private void CreateDirections()
        {
            pointsOfDirection[0] = new Point(1, 0);
            pointsOfDirection[1] = new Point(-1, 0);
            pointsOfDirection[2] = new Point(0, 1);
            pointsOfDirection[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            if(userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }

        private void AskUserForRestart()
        {
            int leftX = wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game over!");
            Environment.Exit(0);
        }
    }
}
