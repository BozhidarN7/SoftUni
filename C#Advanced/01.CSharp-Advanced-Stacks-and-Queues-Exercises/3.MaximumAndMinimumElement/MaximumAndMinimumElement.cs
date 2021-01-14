using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.MaximumAndMinimumElement
{
    class MaximumAndMinimumElement
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < N; i++)
            {
                int[] tokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (tokens[0] == 1)
                {
                    st.Push(tokens[1]);
                }
                else if (tokens[0] == 2 && st.Count != 0)
                {
                    st.Pop();
                }
                else if (tokens[0] == 3 && st.Count != 0)
                {
                    Console.WriteLine(st.Max());
                }
                else if (tokens[0] == 4 && st.Count != 0)
                {
                    Console.WriteLine(st.Min());
                }
            }
            Console.WriteLine(string.Join(", ", st));
        }
    }
}
