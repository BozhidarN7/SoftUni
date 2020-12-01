using System;

namespace _6.ReplaceRepeatingChars
{
    class ReplaceRepeatingChars
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string result = "";
            for (int i = 0; i < str.Length - 1; i++)
            {
                while (i < str.Length -1 && str[i + 1] == str[i])
                {
                    i++;
                }
                result += str[i];
            }
            if (str[str.Length -2] != str[str.Length -1])
            {
                result += str[str.Length - 1];
            }
            Console.WriteLine(result);
        }
    }
}
