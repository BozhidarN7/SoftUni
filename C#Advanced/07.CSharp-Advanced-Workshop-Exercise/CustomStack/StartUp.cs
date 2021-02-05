using System;

namespace CustomStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);

            stack.ForEach(e => Console.WriteLine(e));
        }
    }
}
