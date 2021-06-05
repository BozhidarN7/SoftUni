using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string> phonebook = new Dictionary<string, string>();

        string line = Console.ReadLine();

        while (line != "end")
        {
            var tokens = line.Split('-');

            if (!phonebook.ContainsKey(tokens[0]) && line != "search")
            {
                phonebook.Add(tokens[0], tokens[1]);
            }
            else if (line == "search")
            {
                line = Console.ReadLine();

                while (true)
                {
                    if (phonebook.ContainsKey(line))
                    {
                        Console.WriteLine($"{line} -> {phonebook[line]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {line} does not exist.");
                    }

                    line = Console.ReadLine();

                    if (line == "end")
                    {
                        return;
                    }
                }
            }

            line = Console.ReadLine();
        }
    }
}
