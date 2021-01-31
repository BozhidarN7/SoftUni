using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> guests = new Dictionary<string, int>();
            string[] names = Console.ReadLine().Split();

            foreach (string name in names)
            {
                if (!guests.ContainsKey(name))
                {
                    guests.Add(name, 0);
                }
                guests[name]++;
            }
            string command = Console.ReadLine();
            while (command != "Party!")
            {

                string[] tokens = command.Split();
                List<string> newGuests = new List<string>();
                Func<List<string>, string, List<string>> condition = GetCondition(guests.Keys.ToList(), tokens);
                if (tokens[0] == "Remove")
                {
                    newGuests = condition(guests.Keys.ToList(), tokens[2]);
                    RemoveNewGuests(guests, newGuests);
                }
                if (tokens[0] == "Double")
                {
                    newGuests = condition(guests.Keys.ToList(), tokens[2]);
                    AddNewGuests(guests, newGuests);
                }
                command = Console.ReadLine();
            }
            Print(guests);
        }

        private static void Print(Dictionary<string, int> guests)
        {
            string result = "";
            foreach ((string guest, int occ) in guests)
            {
                for (int i = 0; i < occ; i++)
                {
                    result += $"{guest}, ";
                }
            }
            if (result == string.Empty)
            {
                Console.WriteLine("Nobody is going to the party!");
                return;
            }
            Console.WriteLine($"{result.Substring(0, result.Length - 2)} are going to the party!");
        }

        private static void RemoveNewGuests(Dictionary<string, int> guests, List<string> newGuests)
        {
            foreach (string guest in newGuests)
            {
                if (guests[guest] > 0)
                {
                    guests[guest]=0;
                }
            }
        }

        private static void AddNewGuests(Dictionary<string, int> guests, List<string> newGuests)
        {
            foreach (string guest in newGuests)
            {
                if (guests[guest] > 0)
                {
                    guests[guest] *= 2;
                }
            }
        }

        private static Func<List<string>, string, List<string>> GetCondition(List<string> names, string[] tokens)
        {
            if (tokens[1] == "StartsWith")
            {
                return (names, x) =>
                {
                    List<string> newGuests = new List<string>();
                    names.ForEach(name =>
                   {
                       if (name.StartsWith(x))
                       {
                           newGuests.Add(name);
                       }
                   });
                    return newGuests;
                };
            }
            if (tokens[1] == "EndsWith")
            {
                return (names, x) =>
                {
                    List<string> newGuests = new List<string>();
                    names.ForEach(name =>
                    {
                        if (name.EndsWith(x))
                        {
                            newGuests.Add(name);
                        }
                    });
                    return newGuests;
                };
            }
            if (tokens[1] == "Length")
            {
                return (names, x) =>
                {
                    List<string> newGuests = new List<string>();
                    names.ForEach(name =>
                    {
                        if (name.Length == int.Parse(x))
                        {
                            newGuests.Add(name);
                        }
                    });
                    return newGuests;
                };
            }
            return null;
        }
    }
}
