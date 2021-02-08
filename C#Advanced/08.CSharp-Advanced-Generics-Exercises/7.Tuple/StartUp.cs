using System;

namespace _7.Tuple
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string name = $"{input[0]} {input[1]}";
            string address = input[2];

            Tuple<string, string> tuple1 = new Tuple<string, string>(name, address);
            Console.WriteLine($"{tuple1.Item1} -> {tuple1.Item2}");

            input = Console.ReadLine().Split();
            name = input[0];
            int beer = int.Parse(input[1]);

            Tuple<string, int> tuple2 = new Tuple<string, int>(name, beer);
            Console.WriteLine($"{tuple2.Item1} -> {tuple2.Item2}");

            input = Console.ReadLine().Split();
            int integerNum = int.Parse(input[0]);
            double doubleNum = double.Parse(input[1]);

            Tuple<int, double> tuple3 = new Tuple<int, double>(integerNum, doubleNum);
            Console.WriteLine($"{tuple3.Item1} -> {tuple3.Item2}");

        }
    }
}
