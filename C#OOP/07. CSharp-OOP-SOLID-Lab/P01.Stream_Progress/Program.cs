using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            File file = new File("Programmer.txt", 50, 10);
            StreamProgressInfo spr = new StreamProgressInfo(file);
            Console.WriteLine(spr.CalculateCurrentPercent());

            Music music = new Music("Something", "Something", 100, 10);
            spr = new StreamProgressInfo(music);
            Console.WriteLine($"{spr.CalculateCurrentPercent()}% sent so far");
        }
    }
}
