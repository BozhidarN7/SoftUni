using System;
using System.Linq;

namespace _5.AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            while (command != "end")
            {
                Func<int[], int[]> function = GetFunction(command);
                if (function != null)
                {
                    arr = function(arr);
                }
                else
                {
                    Console.WriteLine(string.Join(" ", arr));
                }
                command = Console.ReadLine();
            }
        }

        private static Func<int[], int[]> GetFunction(string command)
        {
            switch (command)
            {
                case "add": return arr => arr.Select(x => x + 1).ToArray();
                case "multiply": return arr => arr.Select(x => x * 2).ToArray();
                case "subtract": return arr => arr.Select(x => x - 1).ToArray();
            }
            return null;
        }
    }
}
