using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ThePianist
{
    class ThePianist
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> pieces = new Dictionary<string, Dictionary<string, string>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split('|');
                if (!pieces.ContainsKey(tokens[0]))
                {
                    pieces.Add(tokens[0], new Dictionary<string, string>() {
                        {"composer",tokens[1]},
                        {"key", tokens[2]}
                    });
                }
            }

            string command = Console.ReadLine();
            while (command != "Stop")
            {
                string[] tokens = command.Split('|');
                if (tokens[0] == "Add")
                {
                    if (!pieces.ContainsKey(tokens[1]))
                    {
                        pieces.Add(tokens[1], new Dictionary<string, string>() {
                        {"composer",tokens[2]},
                        {"key", tokens[3]}
                    });
                        Console.WriteLine($"{tokens[1]} by {tokens[2]} in {tokens[3]} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{tokens[1]} is already in the collection!");
                    }
                }
                else if (tokens[0] == "Remove")
                {
                    if (pieces.Remove(tokens[1]))
                    {
                        Console.WriteLine($"Successfully removed {tokens[1]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {tokens[1]} does not exist in the collection.");
                    }
                }
                else
                {
                    if (pieces.ContainsKey(tokens[1]))
                    {
                        pieces[tokens[1]]["key"] = tokens[2];
                        Console.WriteLine($"Changed the key of {tokens[1]} to {tokens[2]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {tokens[1]} does not exist in the collection.");
                    }
                }
                command = Console.ReadLine();
            }

            foreach (var piece in pieces.OrderBy(x => x.Key).ThenBy(x => x.Value["composer"]))
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value["composer"]}, Key: {piece.Value["key"]}");
            }
        }
    }
}
