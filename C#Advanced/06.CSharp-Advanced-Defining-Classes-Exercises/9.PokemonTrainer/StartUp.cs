using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            string input = Console.ReadLine();
            while (input != "Tournament")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainer = tokens[0];
                string pokemon = tokens[1];
                string element = tokens[2];
                int health = int.Parse(tokens[3]);

                if (!trainers.ContainsKey(trainer))
                {
                    trainers.Add(trainer, new Trainer(trainer));
                }
                trainers[trainer].Pokemons.Add(new Pokemon(pokemon, element, health));

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Where(x => x.Element == input).Count() != 0)
                    {
                        trainer.Value.Badges++;
                    }
                    else
                    {
                        List<Pokemon> toRemove = new List<Pokemon>();
                        foreach (Pokemon pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;
                            if (pokemon.Health <= 0)
                            {
                                toRemove.Add(pokemon);
                            }
                        }
                        foreach (Pokemon pokemon in toRemove)
                        {
                            trainer.Value.Pokemons.Remove(pokemon);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Value.Badges))
            {
                Console.WriteLine($"{trainer.Key} {trainer.Value.Badges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
