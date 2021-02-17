using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> byPatients = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>[]> byRooms = new Dictionary<string, List<string>[]>();
            Dictionary<string, List<string>> byDoctors = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            while (input != "Output")
            {
                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string department = tokens[0];
                string doctor = tokens[1] + " " + tokens[2];
                string patient = tokens[3];

                if (!byPatients.ContainsKey(department))
                {
                    byPatients.Add(department, new List<string>());
                    byRooms.Add(department, new List<string>[20]);
                    for (int i = 0; i < byRooms[department].Length; i++)
                    {
                        byRooms[department][i] = new List<string>();
                    }

                }
                byPatients[department].Add(patient);

                for (int i = 0; i < byRooms[department].Length; i++)
                {
                    if (byRooms[department][i].Count < 3)
                    {
                        byRooms[department][i].Add(patient);
                        break;
                    }
                }

                if (!byDoctors.ContainsKey(doctor))
                {
                    byDoctors.Add(doctor, new List<string>());
                }
                byDoctors[doctor].Add(patient);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                input = input.Trim();
                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 1)
                {
                    foreach (string patient in byPatients[tokens[0]])
                    {
                        Console.WriteLine(patient);
                    }
                }
                else if (byDoctors.ContainsKey(input))
                {
                    foreach (string patient in byDoctors[input].OrderBy(x => x))
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    foreach (string patient in byRooms[tokens[0]][int.Parse(tokens[1]) - 1].OrderBy(x => x))
                    {
                        Console.WriteLine(patient);
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
