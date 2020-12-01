using System;
using System.ComponentModel;
using System.Numerics;

namespace _8.MathPower
{
    class MathPower
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            double result = Raise(number, power);
            Console.WriteLine(result);
        }

        private static double Raise(double number, double power)
        {
            return Math.Pow(number, power);
        }
    }
}
