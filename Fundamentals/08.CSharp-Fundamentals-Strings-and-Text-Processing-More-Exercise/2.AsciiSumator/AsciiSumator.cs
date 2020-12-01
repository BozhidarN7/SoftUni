using System;

namespace _2.AsciiSumator
{
    class AsciiSumator
    {
        static void Main(string[] args)
        {
            char firstSymbol = char.Parse(Console.ReadLine());
            char secondSymbol = char.Parse(Console.ReadLine());

            string str = Console.ReadLine();
            int sum = 0;
            
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] > firstSymbol && str[i] < secondSymbol)
                {
                    sum += (int)str[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
