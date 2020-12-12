using System;
using System.Linq;

namespace _2.EmailMe
{
    class EmailMe
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            int index = email.IndexOf("@");
            string before = email.Substring(0, index);
            string after = email.Substring(index + 1);

            int difference = before.Sum(x => (int)x) - after.Sum(x => (int)x);
            if (difference >= 0)
            {
                Console.WriteLine("Call her!");
            }
            else
            {
                Console.WriteLine("She is not the one.");
            }
        }
    }
}
