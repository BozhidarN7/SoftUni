using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fishes;

        private string name;

        protected Aquarium(string name, int capacity)
        {
            decorations = new List<IDecoration>();
            fishes = new List<IFish>();
            Name = name;
            Capacity = capacity;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort => decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => decorations.AsReadOnly();

        public ICollection<IFish> Fish => fishes.AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (fishes.Count >= Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            fishes.Add(fish);
        }

        public void Feed()
        {
            fishes.ForEach(x => x.Eat());
        }

        public string GetInfo()
        {
            StringBuilder result = new StringBuilder();
           
            result.AppendLine($"{Name} ({GetType().Name}):");
            if (fishes.Count == 0)
            {
                result.AppendLine("Fish: none");
            }
            else
            {
                result.AppendLine($"Fish: {string.Join(", ", fishes.Select(x => x.Name))}");
            }
            result.AppendLine($"Decorations: {decorations.Count}");
            result.AppendLine($"Comfort: {Comfort}");

            return result.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return fishes.Remove(fish);
        }
    }
}
