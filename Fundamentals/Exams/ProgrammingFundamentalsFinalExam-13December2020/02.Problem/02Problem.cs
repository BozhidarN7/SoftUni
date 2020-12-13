using System;
using System.Text.RegularExpressions;

namespace _02.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex usernamePattern = new Regex(@"(U\$)(?<username>[A-Z][a-z]{2,})\1");
            Regex passwordPattern = new Regex(@"(P\@\$)(?<password>[A-Za-z]{5,}[0-9]+)\1");
            int n = int.Parse(Console.ReadLine());
            int successfulRegistrations = 0;
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string username = usernamePattern.Match(input).Groups["username"].Value;
                string password = passwordPattern.Match(input).Groups["password"].Value;

                if (username != string.Empty && password != string.Empty)
                {
                    Console.WriteLine($"Registration was successful");
                    Console.WriteLine($"Username: {username}, Password: {password}");
                    successfulRegistrations++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {successfulRegistrations}");
        }
    }
}
