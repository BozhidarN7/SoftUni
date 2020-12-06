using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _4.Wheather
{
    class Wheather
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"(?<city>[A-Z]{2})(?<temperature>\d+.\d+)(?<wheather>[A-Za-z]+)\|");
            string input = Console.ReadLine();
            Dictionary<string, City> cities = new Dictionary<string, City>();
            while (input != "end")
            {
                Match match = pattern.Match(input);
                if (match.Success)
                {
                    string city = match.Groups["city"].Value;
                    string wheather = match.Groups["wheather"].Value;
                    double temperature = double.Parse(match.Groups["temperature"].Value);
                    if (!cities.ContainsKey(city))
                    {
                        cities.Add(city, new City());
                    }
                    cities[city].Temperature = temperature;
                    cities[city].Wheather = wheather;
                }

                input = Console.ReadLine();
            }
            foreach (var city in cities.OrderBy(x => x.Value.Temperature))
            {
                Console.WriteLine($"{city.Key} => {city.Value.Temperature} => {city.Value.Wheather}");
            }
        }
    }
    public class City
    {
        public string Wheather { get; set; }
        public double Temperature { get; set; }
    }
}
