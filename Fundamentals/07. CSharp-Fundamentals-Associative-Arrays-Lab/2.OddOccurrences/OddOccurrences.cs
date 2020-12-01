using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.OddOccurrences
{
    class OddOccurrences
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();
            Dictionary<string, int> dic = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();
                if (!dic.ContainsKey(words[i]))
                {
                    dic.Add(words[i], 0);
                }
                dic[words[i]]++;
            }

            foreach (var item in dic)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write(item.Key + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
