using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;

namespace _10.LadyBugs
{
    class LadyBugs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] field = new int[n];

            int[] placement = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < placement.Length; i++)
            {
                field[placement[i]] = 1;
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] line = input.Split();
                int index = int.Parse(line[0]);
                int positions = int.Parse(line[2]);
                int absolutePositions = Math.Abs(positions);
                string direction = line[1];

                if (positions == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (index >= n || index < 0)
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (field[index] == 0)
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (direction == "right")
                {
                    if (positions < 0)
                    {
                        for (int i = index - absolutePositions; i >= 0; i -= absolutePositions)
                        {
                            if (field[i] == 0)
                            {
                                field[i] = 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = index + absolutePositions; i < n; i += absolutePositions)
                        {
                            if (field[i] == 0)
                            {
                                field[i] = 1;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (positions < 0)
                    {
                        for (int i = index + absolutePositions; i < n; i += absolutePositions)
                        {
                            if (field[i] == 0)
                            {
                                field[i] = 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = index - absolutePositions; i >= 0; i -= absolutePositions)
                        {
                            if (field[i] == 0)
                            {
                                field[i] = 1;
                                break;
                            }
                        }
                    }
                }
                field[index] = 0;

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));
        }
    }
}
