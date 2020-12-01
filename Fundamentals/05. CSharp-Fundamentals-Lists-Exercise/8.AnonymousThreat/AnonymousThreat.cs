using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.AnonymousThreat
{
    class AnonymousThreat
    {
        static void Main(string[] args)
        {
            List<string> arr = Console.ReadLine().Split().ToList();
            string command = Console.ReadLine();

            while (command != "3:1")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "merge")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    Merge(arr, startIndex, endIndex);
                }
                else
                {
                    int index = int.Parse(tokens[1]);
                    int partitions = int.Parse(tokens[2]);
                    Divide(arr, index, partitions);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", arr));

        }

        private static void Divide(List<string> arr, int index, int partitions)
        {
            string partionData = arr[index];
            arr.RemoveAt(index);

            int insertIndex = index;
            if (partionData.Length % partitions != 0)
            {
                int i;
                for (i = 0; i < partitions - 1; i++)
                {
                    arr.Insert(insertIndex++, partionData[i].ToString());
                }
                arr.Insert(insertIndex, partionData.Substring(i));
            }
            else
            {
                int length = partionData.Length / partitions;
                int start = 0;
                for (int i = 0; i < partitions; i++)
                {
                    arr.Insert(insertIndex++, partionData.Substring(start, length));
                    start += length;
                }
            }
        }

        private static void Merge(List<string> arr, int startIndex, int endIndex)
        {
            if (startIndex < 0)
            {
                startIndex = 0;
            }

            if (endIndex > arr.Count - 1)
            {
                endIndex = arr.Count - 1;
            }

            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                arr[startIndex] += arr[startIndex + 1];
                arr.RemoveAt(startIndex + 1);
            }
        }
    }
}
