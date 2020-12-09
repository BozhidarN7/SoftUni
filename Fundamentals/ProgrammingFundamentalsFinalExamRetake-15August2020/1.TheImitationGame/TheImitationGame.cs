using System;

namespace _1.TheImitationGame
{
    class TheImitationGame
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Decode")
            {
                string[] tokens = command.Split('|');
                if (tokens[0] == "Move")
                {
                    string partToMove = message.Substring(0, int.Parse(tokens[1]));
                    message = message.Remove(0, int.Parse(tokens[1])) + partToMove;
                }
                else if (tokens[0] == "Insert")
                {
                    message = message.Insert(int.Parse(tokens[1]), tokens[2]);
                }
                else
                {
                    message = message.Replace(tokens[1], tokens[2]);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
