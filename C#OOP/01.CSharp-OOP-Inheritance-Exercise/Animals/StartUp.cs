using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "Beast!")
            {
                if (input == "Cat")
                {
                    string[] tokens = Console.ReadLine().Split();
                    Cat cat = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    Console.WriteLine(cat);
                    Console.WriteLine(cat.ProduceSound());
                }
                else if (input == "Frog")
                {
                    string[] tokens = Console.ReadLine().Split();
                    Frog frog = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    Console.WriteLine(frog);
                    Console.WriteLine(frog.ProduceSound());
                }
                else if( input == "Dog")
                {
                    string[] tokens = Console.ReadLine().Split();
                    Dog dog = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    Console.WriteLine(dog);
                    Console.WriteLine(dog.ProduceSound());
                }
                else if (input == "Tomcat")
                {
                    string[] tokens = Console.ReadLine().Split();
                    Tomcat tomcat = new Tomcat(tokens[0], int.Parse(tokens[1]));
                    Console.WriteLine(tomcat);
                    Console.WriteLine(tomcat.ProduceSound());
                }
                else if(input == "Kitten")
                {
                    string[] tokens = Console.ReadLine().Split();
                    Kitten kitten = new Kitten(tokens[0], int.Parse(tokens[1]));
                    Console.WriteLine(kitten);
                    Console.WriteLine(kitten.ProduceSound());
                }
                input = Console.ReadLine();
            }
        }
    }
}
