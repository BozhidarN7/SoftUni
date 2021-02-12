using System;
using System.Linq;

namespace _3.Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            CustomStack stack = new CustomStack();
            while (input  != "END")
            {
                string[] tokens = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Push")
                {
                    stack.Push(tokens.Skip(1).Select(int.Parse).ToList());
                }
                else if (tokens[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch(InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                input = Console.ReadLine();
            }

            foreach(int item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (int item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
