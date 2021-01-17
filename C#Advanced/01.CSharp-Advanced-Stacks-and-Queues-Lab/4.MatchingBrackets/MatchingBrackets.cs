using System;
using System.Collections.Generic;

namespace _4.MatchingBrackets
{
    class MatchingBrackets
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i< expression.Length; i++)
            {
                if (expression[i]== '(')
                {
                    indexes.Push(i);
                }
                if (expression[i] == ')')
                {
                    int index = indexes.Pop();
                    string currentExpression = expression.Substring(index, i - index + 1);
                    Console.WriteLine(currentExpression);
                }
            }
        }
    }
}
