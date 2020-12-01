using System;
using System.Numerics;

namespace _11.Snowballs
{
    class Snowballs
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int bestSnowballSnow = 0;
            int bestSnowballTime = 0;
            int bestSnowballQuality = 0;

            BigInteger bestSnowballValue = new BigInteger();

            for (int i = 0; i < n; i++)
            {
                int currentSnowballSnow = int.Parse(Console.ReadLine());
                int currentSnowballTime = int.Parse(Console.ReadLine());
                int currentSnowballQuality = int.Parse(Console.ReadLine());

                BigInteger currentSnowballValue = new BigInteger();
                currentSnowballValue = BigInteger.Pow((currentSnowballSnow / currentSnowballTime), currentSnowballQuality);

                if (currentSnowballValue >= bestSnowballValue)
                {
                    bestSnowballSnow = currentSnowballSnow;
                    bestSnowballTime = currentSnowballTime;
                    bestSnowballValue = currentSnowballValue;
                    bestSnowballQuality = currentSnowballQuality;
                }
            }

            Console.WriteLine($"{bestSnowballSnow} : {bestSnowballTime} = {bestSnowballValue} ({bestSnowballQuality})");

        }
    }
}
