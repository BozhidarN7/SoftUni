using System;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RandomList rl = new RandomList();
            rl.Add("1");
            rl.Add("2");
            rl.Add("3");
            rl.Add("4");
            Console.WriteLine(rl.RandomString());
            Console.WriteLine(string.Join(" ", rl));
        }
    }
}
