using System;

namespace _01.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string command = Console.ReadLine();
            while (command != "Complete")
            {
                string[] tokens = command.Split();
                if (tokens[0] == "Make" && tokens[1] == "Upper")
                {
                    email = email.ToUpper();
                    Console.WriteLine(email);
                }
                else if (tokens[0] == "Make" && tokens[1] == "Lower")
                {
                    email = email.ToLower();
                    Console.WriteLine(email);
                }
                else if (tokens[0] == "GetDomain")
                {
                    Console.WriteLine(email.Substring(email.Length - int.Parse(tokens[1])));
                }
                else if (tokens[0] == "GetUsername")
                {
                    int index = email.IndexOf("@");
                    if (index == -1)
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                    else
                    {
                        Console.WriteLine(email.Substring(0, index));
                    }
                }
                else if (tokens[0] == "Replace")
                {
                    email = email.Replace(tokens[1], "-");
                    Console.WriteLine(email);
                }
                else
                {
                    for (int i = 0; i < email.Length; i++)
                    {
                        Console.Write((int)email[i] + " ");
                    }
                    Console.WriteLine();
                }
                command = Console.ReadLine();
            }
        }
    }
}
