using System;

namespace _1.WorldTour
{
    class WorldTour
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Travel")
            {
                string[] tokens = command.Split(":");
                if (tokens[0] == "Add Stop")
                {
                    int index = int.Parse(tokens[1]);
                    if (index >= 0 && index < stops.Length)
                    {
                        stops = stops.Insert(index, tokens[2]);
                    }
                }
                else if (tokens[0] == "Remove Stop")
                {
                    int start = int.Parse(tokens[1]);
                    int end = int.Parse(tokens[2]);
                    if (start > end)
                    {
                        start ^= end;
                        end = start ^ end;
                        start ^= end;
                    }
                    if (start >= 0 && start < stops.Length && end >= 0 && end < stops.Length)
                    {
                        stops = stops.Remove(start, end - start + 1);
                    }
                }
                else
                {
                    if (stops.Contains(tokens[1]))
                    {
                        stops = stops.Replace(tokens[1], tokens[2]);
                    }
                }
                Console.WriteLine(stops);
                command = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
