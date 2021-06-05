using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Parentheses
{
    class Parentheses
    {
        private static StringBuilder builder = new StringBuilder();

        private static List<char> parentheses = new List<char>();

        static void Main(string[] args)
        {
            int pairs = int.Parse(Console.ReadLine());

            Generate(pairs, 0, 0);

            Console.Write(builder);
        }

        private static void Generate(int pairs, int open, int close)
        {
            if (open == pairs && close == pairs)
            {
                Check();

            }

            if (open < pairs)
            {
                if (close == pairs && open < pairs)
                {
                    return;
                }
                parentheses.Add('(');
                Generate(pairs, open + 1, close);
                parentheses.RemoveAt(parentheses.Count - 1);
            }

            if (close < pairs)
            {
                parentheses.Add(')');
                Generate(pairs, open, close + 1);
                parentheses.RemoveAt(parentheses.Count - 1);

            }

        }

        private static void Check()
        {
            Stack<char> stack = new Stack<char>();

            bool match = true;

            for (int i = 0; i < parentheses.Count; i++)
            {
                if (parentheses[i] == '(')
                {
                    stack.Push(parentheses[i]);
                }
                else
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        match = false;
                        break;
                    }
                }
            }

            if (match)
            {
                Print();
            }
        }

        private static void Print()
        {
            for (int i = 0; i < parentheses.Count; i++)
            {
                builder.Append(parentheses[i]);
            }
            builder.AppendLine();
        }
    }
}
