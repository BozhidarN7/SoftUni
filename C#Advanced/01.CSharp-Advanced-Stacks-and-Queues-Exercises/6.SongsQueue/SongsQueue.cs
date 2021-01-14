using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.SongsQueue
{
    class SongsQueue
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(Console.ReadLine().Split(", "));
            string command = Console.ReadLine();
            while (songs.Count != 0)
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Play")
                {
                    if (songs.Count != 0)
                    {
                        songs.Dequeue();
                    }
                    
                }
                else if (tokens[0] == "Add")
                {
                    string song = string.Join(" ", tokens.Skip(1).ToArray());
                    if (!songs.Contains(song))
                    {
                        songs.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                else if (tokens[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
                command = Console.ReadLine();
            }
            Console.WriteLine("No more songs!");
        }
    }
}
