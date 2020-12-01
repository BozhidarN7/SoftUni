using System;
using System.Linq;
using System.Threading.Tasks.Sources;

namespace Login
{
    class Login
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            char[] passwordArray = password.ToCharArray();
            Array.Reverse(passwordArray);
            string correctPassword = new string(passwordArray);

            string input = Console.ReadLine();
            int tryCount = 0;
            bool isBlocked = false;
            while (input != correctPassword)
            {
                tryCount++;
                if (tryCount == 4)
                {
                    Console.WriteLine("User {0} blocked!", password);
                    input = Console.ReadLine();
                    isBlocked = true;
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
                input = Console.ReadLine();
            }

            if (!isBlocked)
            {
                Console.WriteLine("User {0} logged in.", password);
            }
        }
    }
}
