using System;
using System.ComponentModel;

namespace _3.Calculations
{
    class Calculations
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            switch (operation)
            {
                case "subtract":
                    Substract(a, b);
                    break;
                case "add":
                    Add(a, b);
                    break;
                case "divide":
                    Divide(a, b);
                    break;
                case "multiply":
                    Multiply(a, b);
                    break;
                default:
                    break;
            }
        }

        private static void Divide(int a, int b)
        {
            Console.WriteLine(a / b);
        }

        private static void Multiply(int a, int b)
        {
            Console.WriteLine(a * b);
        }

        private static void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        private static void Substract(int a, int b)
        {
            Console.WriteLine(a - b);
        }
    }
}
