using System;
using System.Text;

namespace _1.PasswordReset
{
    class PasswordReset
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] tokens = command.Split();
                if (tokens[0] == "TakeOdd")
                {
                    string current = "";
                    for (int i = 1; i < password.Length; i += 2)
                    {
                        current += password[i];
                    }
                    password = current;
                    Console.WriteLine(password);
                }
                else if (tokens[0] == "Cut")
                {
                    int index = int.Parse(tokens[1]);
                    int lenght = int.Parse(tokens[2]);
                    password = password.Remove(index, lenght);
                    Console.WriteLine(password);
                }
                else
                {
                    if (password.Contains(tokens[1]))
                    {
                        password = password.Replace(tokens[1], tokens[2]);
                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
