using System;
using System.Collections.Generic;

namespace _11.PartyReservationFilterModule
{
    class PartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            string[] guests = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string input = Console.ReadLine();
            HashSet<string> filters = new HashSet<string>();
            while (input != "Print")
            {
                string command = input.Substring(0, input.IndexOf(';'));
                if (command.StartsWith("Add"))
                {
                    filters.Add(input.Substring(input.IndexOf(';') + 1));
                }
                if (command.StartsWith("Remove"))
                {
                    filters.Remove(input.Substring(input.IndexOf(';') + 1));
                }
                input = Console.ReadLine();
            }
            foreach (string guest in guests)
            {
                if (FilterGuests(filters, guest))
                {
                    Console.Write(guest + " ");
                }
            }
        }

        private static bool FilterGuests(HashSet<string> filters, string guest)
        {
            foreach (string filter in filters)
            {
                string[] tokens = filter.Split(';', StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0].StartsWith("Starts"))
                {
                    if (guest.StartsWith(tokens[1]))
                    {
                        return false;
                    }
                }
                else if (tokens[0].StartsWith("Ends"))
                {
                    if (guest.EndsWith(tokens[1]))
                    {
                        return false;
                    }
                }
                else if (tokens[0].StartsWith("Length"))
                {
                    if (guest.Length == int.Parse(tokens[1]))
                    {
                        return false;
                    }
                }
                else if (tokens[0].StartsWith("Contains"))
                {
                    if (guest.Contains(tokens[1]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
