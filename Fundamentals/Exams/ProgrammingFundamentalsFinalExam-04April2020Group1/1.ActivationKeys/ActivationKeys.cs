using System;

namespace _1.ActivationKeys
{
    class ActivationKeys
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string command = Console.ReadLine();
            while (command != "Generate")
            {
                string[] tokens = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Contains")
                {
                    if (activationKey.Contains(tokens[1]))
                    {
                        Console.WriteLine($"{activationKey} contains {tokens[1]}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (tokens[0] == "Flip")
                {
                    int startIndex = int.Parse(tokens[2]);
                    int endIndex = int.Parse(tokens[3]);
                    string first = activationKey.Substring(0, startIndex);
                    string middle = activationKey.Substring(startIndex, endIndex - startIndex);
                    string end = activationKey.Substring(endIndex);
                    if (tokens[1] == "Upper")
                    {
                        middle = middle.ToUpper();
                    }
                    else
                    {
                        middle = middle.ToLower();
                    }
                    activationKey = first + middle + end;
                    Console.WriteLine(activationKey);
                }
                else
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    activationKey = activationKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(activationKey);
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
