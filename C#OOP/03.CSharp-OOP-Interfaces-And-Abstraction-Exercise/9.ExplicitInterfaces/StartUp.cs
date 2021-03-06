using System;

namespace _9.ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Citizen citizen = new Citizen(tokens[0], tokens[1], int.Parse(tokens[2]));
                IPerson person = citizen;
                Console.WriteLine(person.GetName());

                IResident resident = citizen;
                Console.WriteLine(resident.GetName());

                line = Console.ReadLine();
            }
        }
    }
}
