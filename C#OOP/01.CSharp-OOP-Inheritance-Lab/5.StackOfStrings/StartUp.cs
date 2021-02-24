using System;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StackOfStrings cs = new StackOfStrings();
            cs.Push("1");
            cs.Push("2");
            cs.Push("3");
            cs.Push("4");
            cs.AddRange(new string[] { "5", "6" });
            Console.WriteLine(string.Join(" ", cs));
        }
    }
}
