using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        // Problem 1.	Sum and Average
        /*string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        List<int> list = new List<int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            list.Add(int.Parse(numbers[i]));
        }

        double sum = 0;
        for (int i = 0; i < list.Count; i++)
        {
            sum = sum + list[i];
        }
        double average = sum / list.Count;
        Console.Write("Sum={0}; ",sum);
        Console.WriteLine("Average={0:f2}", average);
        */

        // Problem 2.	Sort Words
        /*string input = Console.ReadLine();
        string[] words = input.Split(' ');
        Array.Sort(words);
        List<string> list = new List<string>();
        list = words.ToList();
        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        */

        // Problem 3.	Longest Subsequence
        /*string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        List<int> list = new List<int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            list.Add((int.Parse(numbers[i])));
        }
        if (list.Count == 1)
        {
            Console.WriteLine(list[0]);
        }
        else
        {
            FindLongestSubsequanceOfEqualNumbers(list);
        }
        */

        // Problem 4.	Remove Odd Occurrences
        /*string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        List<int> list = new List<int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            list.Add(int.Parse(numbers[i]));
        }

        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        foreach (var item in list)
        {
            if (dictionary.ContainsKey(item))
            {
                dictionary[item]++;
            }
            else
            {
                dictionary[item] = 1;
            }
        }

        foreach (var item in dictionary)
        {
            if (item.Value % 2 != 0)
            {
                int timesToDeLete = item.Value;
                while (timesToDeLete != 0)
                {
                    list.Remove(item.Key);
                    timesToDeLete--;
                }
            }
        }

        foreach (var item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        */
        // Problem 5.	Count of Occurrences
        /*string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        foreach (var item in numbers)
        {
            if (dictionary.ContainsKey(item))
            {
                dictionary[item]++;
            }
            else
            {
                dictionary[item] = 1;
            }
        }

        foreach (var item in dictionary)
        {
            Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
        }
        */


        // Problem 1.	Reverse Numbers with a Stack
        /*string input = Console.ReadLine();
        string[] numbers = input.Split();
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            stack.Push(Convert.ToInt32(numbers[i]));
        }
        foreach (var item in stack)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
        */


        // Problem 2.	Calculate Sequence with a Queue
        /*int n = int.Parse(Console.ReadLine());
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(n);
        Console.Write(n + ", ");
        int currentNimber = 0;
        int index = 0;
        for (int i = 1; i < 50; i++)
        {
            if (index == 0)
            {
                currentNimber = queue.Dequeue();
            }
            switch (index)
            {
                case 0:
                    {
                        int S = currentNimber + 1;
                        queue.Enqueue(S);
                        if (i == 49)
                        {
                            Console.Write(S);
                        }
                        else
                        {
                            Console.Write(S + ", ");
                        }
                        index++;
                        break;
                    }
                case 1:
                    {
                        int S = 2 * currentNimber + 1;
                        queue.Enqueue(S);
                        Console.Write(S + ", ");
                        index++;
                        break;
                    }
                case 2:
                    {
                        int S = currentNimber + 2;
                        queue.Enqueue(S);
                        index = 0;
                        Console.Write(S + ", ");
                        break;
                    }
            }
        }
        Console.WriteLine();
        */
    }

    // Problem 3.	Longest Subsequence
    /*private static void FindLongestSubsequanceOfEqualNumbers(List<int> list)
    {
        List<int> longestSubsequence = new List<int>();
        int lastPostion = 0;

        for (int i = lastPostion; i < list.Count - 1; i++)
        {
            int index = i;
            if (index == 0)
            {
                longestSubsequence.Add(list[index]);
                while (list[index] == list[index + 1])
                {
                    longestSubsequence.Add(list[index++ + 1]);
                    if (index == list.Count - 1)
                    {
                        break;
                    }
                }
                lastPostion = index + 1;
                continue;
            }

            int count = 1;
            List<int> newLongestSubsequence = new List<int>();
            newLongestSubsequence.Add(list[index]);
            while (list[index] == list[index + 1])
            {
                newLongestSubsequence.Add(list[index++ + 1]);
                count++;
                if (index == list.Count - 1)
                {
                    break;
                }
            }
            lastPostion = index + 1;
            if (count > longestSubsequence.Count)
            {
                longestSubsequence = new List<int>();

                for (int j = 0; j < newLongestSubsequence.Count; j++)
                {
                    longestSubsequence.Add(newLongestSubsequence[j]);
                }
            }
        }

        foreach (var item in longestSubsequence)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    */
}

