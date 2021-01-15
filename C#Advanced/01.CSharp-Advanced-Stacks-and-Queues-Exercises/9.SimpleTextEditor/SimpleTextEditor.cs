using System;
using System.Collections.Generic;

namespace _9.SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> lastState = new Stack<string>();
            string str = string.Empty;
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                if (tokens[0] == "1")
                {
                    str += tokens[1];
                    lastState.Push(str);
                }
                else if (tokens[0] == "2")
                {
                    str = str.Substring(0, str.Length - int.Parse(tokens[1]));
                    lastState.Push(str);
                }
                else if (tokens[0] == "3")
                {
                    Console.WriteLine(str[int.Parse(tokens[1]) - 1]);
                }
                else
                {
                    lastState.Pop();
                    if (lastState.Count != 0)
                    {
                        str = lastState.Peek();
                    }
                    else
                    {
                        str = string.Empty;
                    }
                }
            }
        }
    }
}
