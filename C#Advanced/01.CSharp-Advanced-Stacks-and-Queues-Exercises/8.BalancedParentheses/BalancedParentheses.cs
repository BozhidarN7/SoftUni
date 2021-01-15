using System;
using System.Collections.Generic;

namespace _8.BalancedParentheses
{
    class BalancedParentheses
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            bool isBalanced = IsBalanced(expression);

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private static bool IsBalanced(string expression)
        {
            Stack<char> openBrackets = new Stack<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (openBrackets.Count == 0 && (expression[i] == ')' || expression[i] == '}' || expression[i] == ']'))
                {
                    return false;
                }

                if (expression[i] == '(' || expression[i] == '{' || expression[i] == '[')
                {
                    openBrackets.Push(expression[i]);
                }
                else
                {
                    if (expression[i] == ')' && openBrackets.Peek() != '(')
                    {
                        return false;
                    }
                    else if (expression[i] == '}' && openBrackets.Peek() != '{')
                    {
                        return false;
                    }
                    else if (expression[i] == ']' && openBrackets.Peek() != '[')
                    {
                        return false;
                    }
                    else if (expression[i] == ')' && openBrackets.Peek() == '(')
                    {
                        openBrackets.Pop();
                    }
                    else if (expression[i] == '}' && openBrackets.Peek() == '{')
                    {
                        openBrackets.Pop();
                    }
                    else if (expression[i] == ']' && openBrackets.Peek() == '[')
                    {
                        openBrackets.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
