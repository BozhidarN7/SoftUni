using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;

namespace _11.ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "exchange")
                {
                    if (int.Parse(tokens[1]) >= arr.Length || int.Parse(tokens[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        Exchange(arr, int.Parse(tokens[1]));
                    }
                }
                if (tokens[0] == "max")
                {
                    if (tokens[1] == "odd")
                    {
                        int index = FindMaxOddElement(arr);
                        if (index < 0)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(index);
                        }
                    }
                    else
                    {
                        int index = FindMaxEvenElement(arr);
                        if (index < 0)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(index);
                        }
                    }
                }
                if (tokens[0] == "min")
                {
                    if (tokens[1] == "odd")
                    {
                        int index = FindMinOddElement(arr);
                        if (index < 0)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(index);
                        }
                    }
                    else
                    {
                        int index = FindMinEvenElement(arr);
                        if (index < 0)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(index);
                        }
                    }
                }
                if (tokens[0] == "first")
                {
                    if (int.Parse(tokens[1]) > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else if (tokens[2] == "odd")
                    {
                        List<int> elements = TakeFirstNOdds(arr, int.Parse(tokens[1]));
                        PrintElements(elements);
                    }
                    else
                    {
                        List<int> elements = TakeFirstNEven(arr, int.Parse(tokens[1]));
                        PrintElements(elements);
                    }
                }
                if (tokens[0] == "last")
                {
                    if (int.Parse(tokens[1]) > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else if (tokens[2] == "odd")
                    {
                        List<int> elements = TakeLastNOdds(arr, int.Parse(tokens[1]));
                        PrintElements(elements);
                    }
                    else
                    {
                        List<int> elements = TakeLastNEven(arr, int.Parse(tokens[1]));
                        PrintElements(elements);
                    }
                }
                command = Console.ReadLine();
            }

            PrintElements(arr.ToList());
        }

        private static void PrintElements(List<int> elements)
        {
            Console.Write("[");
            for (int i = 0; i < elements.Count; i++)
            {
                if (i == elements.Count - 1)
                {
                    Console.Write(elements[i]);
                    continue;
                }
                Console.Write($"{elements[i]}, ");
            }
            Console.WriteLine("]");
        }

        private static List<int> TakeLastNEven(int[] arr, int n)
        {
            List<int> elements = new List<int>();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] != 0 && arr[i] % 2 == 0 && elements.Count < n)
                {
                    elements.Add(arr[i]);
                }
            }
            return elements;
        }

        private static List<int> TakeLastNOdds(int[] arr, int n)
        {
            List<int> elements = new List<int>();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] % 2 != 0 && elements.Count < n)
                {
                    elements.Add(arr[i]);
                }
            }
            return elements;
        }

        private static List<int> TakeFirstNEven(int[] arr, int n)
        {
            List<int> elements = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0 && arr[i] % 2 == 0 && elements.Count < n)
                {
                    elements.Add(arr[i]);
                }
            }
            return elements;
        }

        private static List<int> TakeFirstNOdds(int[] arr, int n)
        {
            List<int> elements = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0 && elements.Count < n)
                {
                    elements.Add(arr[i]);
                }
            }
            return elements;
        }

        private static int FindMinEvenElement(int[] arr)
        {
            int index = -1;
            int min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0 && arr[i] % 2 == 0 && min >= arr[i])
                {
                    min = arr[i];
                    index = i; ;
                }
            }
            return index;
        }

        private static int FindMinOddElement(int[] arr)
        {
            int index = -1;
            int min = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0 && min >= arr[i])
                {
                    min = arr[i];
                    index = i; ;
                }
            }
            return index;
        }

        private static int FindMaxEvenElement(int[] arr)
        {
            int index = -1;
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0 && arr[i] % 2 == 0 && max <= arr[i])
                {
                    max = arr[i];
                    index = i; ;
                }
            }
            return index;
        }

        private static int FindMaxOddElement(int[] arr)
        {
            int index = 0;
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0 && max <= arr[i])
                {
                    max = arr[i];
                    index = i; ;
                }
            }
            return index;
        }

        private static void Exchange(int[] arr, int length)
        {
            int[] partOne = new int[length + 1];
            int[] partTwo = new int[arr.Length - (length + 1)];

            for (int i = 0; i < partOne.Length; i++)
            {
                partOne[i] = arr[i];
            }
            for (int i = 0; i < partTwo.Length; i++)
            {
                partTwo[i] = arr[i + length + 1];
            }

            for (int i = 0; i < partTwo.Length; i++)
            {
                arr[i] = partTwo[i];
            }
            for (int i = 0; i < partOne.Length; i++)
            {
                arr[i + partTwo.Length] = partOne[i];
            }
        }
    }
}
