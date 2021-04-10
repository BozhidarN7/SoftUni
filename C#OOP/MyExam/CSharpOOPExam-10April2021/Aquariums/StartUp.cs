namespace Aquariums
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            Aquarium aquarium1 = new Aquarium("Test", 3);
            for (int i = 0; i < aquarium1.Capacity; i++)
            {
                aquarium1.Add(new Fish($"Pesho {i}"));
            }
            aquarium1.SellFish("Pesho 0");
            Console.WriteLine(aquarium1.Report());
        }
    }
}
