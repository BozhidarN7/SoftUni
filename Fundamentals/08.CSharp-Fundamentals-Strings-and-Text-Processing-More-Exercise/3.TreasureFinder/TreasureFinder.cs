using System;
using System.Linq;

namespace _3.TreasureFinder
{
    class TreasureFinder
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string input = Console.ReadLine();
            while (input != "find")
            {
                int keyIndex = 0;
                char[] str = input.ToCharArray();
                for (int i =0; i < str.Length; i++)
                {
                    if (keyIndex == keys.Length)
                    {
                        keyIndex = 0;
                    }

                    str[i] = (char)((int)input[i] - keys[keyIndex++]);
                }
                input = string.Join("", str);

                int start = input.IndexOf('&');
                int end = input.LastIndexOf('&');
                string treasure = input.Substring(start + 1, end - start - 1);

                start = input.IndexOf('<');
                end = input.IndexOf('>');
                string coordinates = input.Substring(start + 1, end - start - 1);

                Console.WriteLine($"Found {treasure} at {coordinates}");

                input = Console.ReadLine();
            }
        }
    }
}
