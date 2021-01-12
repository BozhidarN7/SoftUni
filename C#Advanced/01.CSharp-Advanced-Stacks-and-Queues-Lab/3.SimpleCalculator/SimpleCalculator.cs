using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split();
            Stack<string> st = new Stack<string>(expression.Reverse().ToArray());

            while (st.Count != 1)
            {
                int firstNumber = int.Parse(st.Pop());
                string operation = st.Pop();
                int secondNumber = int.Parse(st.Pop());

                if (operation == "+")
                {
                    st.Push((firstNumber + secondNumber).ToString());
                }
                else
                {
                    st.Push((firstNumber - secondNumber).ToString());
                }
            }
            Console.WriteLine(st.Pop());
        }
    }
}
