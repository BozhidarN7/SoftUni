using System;
using System.Linq;

namespace _1.SecretChat
{
    class SecretChat
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Reveal")
            {
                string[] tokens = command.Split(":|:");
                if (tokens[0] == "InsertSpace")
                {
                    message = message.Insert(int.Parse(tokens[1]), " ");
                }
                else if (tokens[0] == "Reverse")
                {
                    if (message.Contains(tokens[1]))
                    {
                        message = message.Remove(message.IndexOf(tokens[1]), tokens[1].Length);
                        message += new string(tokens[1].Reverse().ToArray());
                    }
                    else
                    {
                        Console.WriteLine("error");
                        command = Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    message = message.Replace(tokens[1], tokens[2]);
                }
                Console.WriteLine(message);

                command = Console.ReadLine();
            }
            Console.WriteLine("You have a new text message: {0}", message);
        }
    }
}
