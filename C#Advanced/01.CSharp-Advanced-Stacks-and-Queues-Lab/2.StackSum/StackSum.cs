using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class StackSum
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                st.Push(numbers[i]);
            }
            string command = Console.ReadLine();
            while (command.ToLower() != "end")
            {
                string[] tokens = command.Split();
                if (tokens[0].ToLower() == "add")
                {
                    st.Push(int.Parse(tokens[1]));
                    st.Push(int.Parse(tokens[2]));
                }
                else if (tokens[0].ToLower() == "remove")
                {
                    if (int.Parse(tokens[1]) <= st.Count)
                    {
                        for (int i = 0; i < int.Parse(tokens[1]); i++)
                        {
                            st.Pop();
                        } 
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Sum: {st.Sum()}");
        }
    }
}
