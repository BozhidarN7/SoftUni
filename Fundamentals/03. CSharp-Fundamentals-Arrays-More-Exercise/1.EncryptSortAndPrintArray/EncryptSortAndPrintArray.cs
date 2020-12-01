using System;

namespace _1.EncryptSortAndPrintArray
{
    class EncryptSortAndPrintArray
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int encrypted = 0;
                for (int j = 0; j < input.Length; j++)
                {
                    bool isVowel = "aeiouAEIOU".IndexOf(input[j]) >= 0;

                    if (isVowel)
                    {
                        encrypted += (int)input[j] * input.Length;
                    }
                    else
                    {
                        encrypted += (int)input[j] / input.Length;
                    }
                }

                arr[i] = encrypted;

            }
            Array.Sort(arr);
            foreach (int item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
