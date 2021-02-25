using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Bear bear = new Bear("Ivan");
            Console.WriteLine(typeof(Bear));
        }
    }
}