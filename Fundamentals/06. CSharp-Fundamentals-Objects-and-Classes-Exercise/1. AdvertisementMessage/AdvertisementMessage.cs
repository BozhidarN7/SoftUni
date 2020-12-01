using System;
using System.Collections.Generic;

namespace _1._AdvertisementMessage
{
    class AdvertisementMessage
    {
        static void Main(string[] args)
        {
            List<string> phrases = new List<string> { "Excellent product.", "Such a great product.", "I always use that product.", 
                "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            List<string> events = new List<string> { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                    "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"};
            List<string> authors = new List<string> { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            List<string> cities = new List<string> { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int numberOfMaessages = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            for (int i = 0; i< numberOfMaessages;i++)
            {
                int phrasesIndex = rnd.Next(phrases.Count);
                int eventsIndex = rnd.Next(events.Count);
                int authorsIndex = rnd.Next(authors.Count);
                int CitiesIndex = rnd.Next(cities.Count);

                Console.WriteLine($"{phrases[phrasesIndex]} {events[eventsIndex]} {authors[authorsIndex]} - {cities[CitiesIndex]}");
            }
        }
    }
}
