using System;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] tokens = input.Split().Skip(1).ToArray();
            ListyIterator<string> list = new ListyIterator<string>(tokens);
            while (input != "END")
            {
                input = Console.ReadLine();
                if (input == "Print")
                {
                    try
                    {
                        list.Print();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (input == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (input == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
            }
        }
    }
}
