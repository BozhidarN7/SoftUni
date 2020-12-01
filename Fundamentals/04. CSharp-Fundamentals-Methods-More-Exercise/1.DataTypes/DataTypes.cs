using System;

namespace _1.DataTypes
{
    class DataTypes
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            if (dataType =="string")
            {
                string input = Console.ReadLine();
                Console.WriteLine($"${input}$");
            }
            else if (dataType =="real")
            {
                double number = double.Parse(Console.ReadLine());
                Console.WriteLine($"{number * 1.5:f2}");
            }
            else
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine(number * 2);
            }
        }
    }
}
