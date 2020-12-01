using System;
using System.Collections.Generic;

namespace _1.ExtractPersonInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                List<int> nameStartPoitns = new List<int>();
                List<int> nameEndPoints = new List<int>();
                List<int> ageStartPoints = new List<int>();
                List<int> ageEndsPoints = new List<int>();
                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == '@')
                    {
                        nameStartPoitns.Add(j);
                    }
                    if (input[j] == '|')
                    {
                        nameEndPoints.Add(j);
                    }
                    if (input[j] == '#')
                    {
                        ageStartPoints.Add(j);
                    }
                    if (input[j] == '*')
                    {
                        ageEndsPoints.Add(j);
                    }
                }

                for (int j = 0; j < nameStartPoitns.Count; j++)
                {
                    int start = nameStartPoitns[j];
                    int end = nameEndPoints[j];
                    string name = input.Substring(start + 1, end - start - 1);

                    start = ageStartPoints[j];
                    end = ageEndsPoints[j];
                    string age = input.Substring(start + 1, end - start - 1);

                    Console.WriteLine($"{name} is {age} years old.");
                }
            }
        }
    }
}
