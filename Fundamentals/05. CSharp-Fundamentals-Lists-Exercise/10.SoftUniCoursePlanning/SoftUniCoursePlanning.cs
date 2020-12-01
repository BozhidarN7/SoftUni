using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class SoftUniCoursePlanning
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> exercises = new List<int>(new int[lessons.Count]);

            for (int i = 0; i < lessons.Count; i++)
            {
                string current = lessons[i].Trim();
                lessons[i] = current;
            }

            string command = Console.ReadLine();

            while (command != "course start")
            {
                string[] tokens = command.Split(":");

                if (tokens[0] == "Add")
                {
                    if (!lessons.Contains(tokens[1]))
                    {
                        lessons.Add(tokens[1]);
                        exercises.Add(0);
                    }
                }
                else if (tokens[0] == "Insert")
                {
                    if (!lessons.Contains(tokens[1]))
                    {
                        lessons.Insert(int.Parse(tokens[2]), tokens[1]);
                        exercises.Insert(int.Parse(tokens[2]), 0);
                    }
                }
                else if (tokens[0] == "Remove")
                {
                    int index = lessons.IndexOf(tokens[1]);
                    if (index != -1)
                    {
                        lessons.RemoveAt(index);
                        exercises.RemoveAt(index);
                    }
                }
                else if (tokens[0] == "Swap")
                {
                    if (lessons.Contains(tokens[1]) && lessons.Contains(tokens[2]))
                    {
                        int i = lessons.IndexOf(tokens[1]);
                        int j = lessons.IndexOf(tokens[2]);

                        string temp = lessons[i];
                        lessons[i] = lessons[j];
                        lessons[j] = temp;

                        int value = exercises[i];
                        exercises[i] = exercises[j];
                        exercises[j] = value;
                    }
                }
                else
                {
                    int index = 0;
                    if (lessons.Contains(tokens[1]))
                    {
                        index = lessons.IndexOf(tokens[1]);
                        exercises[index] = 1;
                    }
                    else
                    {
                        lessons.Add(tokens[1]);
                        exercises.Add(1);
                    }
                }
                command = Console.ReadLine();
            }

            int order = 1;
            for (int i = 0; i < lessons.Count; i++)
            {
                Console.WriteLine($"{order++}.{lessons[i]}");
                if (exercises[i] == 1)
                {
                    Console.WriteLine($"{order++}.{lessons[i]}-Exercise");
                }
            }
        }
    }
}
