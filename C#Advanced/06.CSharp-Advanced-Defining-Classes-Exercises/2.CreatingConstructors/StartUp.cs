using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person1 = new Person("Ivan", 3);
            Console.WriteLine(person1.Age);
        }
    }
}
