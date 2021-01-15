using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    class Crossroads
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            string input = Console.ReadLine();
            int totalCarsPassed = 0;
            while (input != "END")
            {
                if (input == "green")
                {
                    int time = greenLight;
                    while (cars.Count != 0 && time > 0)
                    {
                        string currentCar = cars.Peek();
                        if (currentCar.Length <= time)
                        {
                            time -= currentCar.Length;
                            cars.Dequeue();
                            totalCarsPassed++;
                        }
                        else
                        {
                            time -= currentCar.Length;
                            break;
                        }
                    }
                    if (cars.Count != 0 && time < 0)
                    {
                        string currentCar = cars.Dequeue();
                        int index = currentCar.Length + time;
                        time = index;
                        if (time + freeWindow < currentCar.Length)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCar[index + freeWindow]}.");
                            return;
                        }
                        else
                        {
                            totalCarsPassed++;
                        }
                    }

                }
                else
                {
                    cars.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
