using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly Dictionary<string, IAquarium> aquariums;
        private readonly IRepository<IDecoration> decorationRepository;

        public Controller()
        {
            aquariums = new Dictionary<string, IAquarium>();
            decorationRepository = new DecorationRepository();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                aquariums.Add(aquariumName, new FreshwaterAquarium(aquariumName));
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquariums.Add(aquariumName, new SaltwaterAquarium(aquariumName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                decorationRepository.Add(new Ornament());
            }
            else if (decorationType == "Plant")
            {
                decorationRepository.Add(new Plant());
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);

        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;
            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            if (aquariums[aquariumName].GetType().Name.StartsWith("Freshwater") && fishType.StartsWith("Freshwater"))
            {
                aquariums[aquariumName].AddFish(fish);
            }
            else if (aquariums[aquariumName].GetType().Name.StartsWith("Saltwater") && fishType.StartsWith("Saltwater"))
            {
                aquariums[aquariumName].AddFish(fish);
            }
            else
            {
                return OutputMessages.UnsuitableWater;
            }

            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            decimal aquariumValue = aquariums[aquariumName].Fish.Sum(x => x.Price) + aquariums[aquariumName].Decorations.Sum(x => x.Price);
            return string.Format(OutputMessages.AquariumValue, aquariumName, aquariumValue);
        }

        public string FeedFish(string aquariumName)
        {
            aquariums[aquariumName].Feed();
            return string.Format(OutputMessages.FishFed, aquariums[aquariumName].Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorationRepository.FindByType(decorationType);
            if (decoration is null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            decorationRepository.Remove(decoration);
            aquariums[aquariumName].AddDecoration(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            foreach((string aquariumName,IAquarium aquarium) in aquariums)
            {
                result.AppendLine(aquarium.GetInfo());
            }

            return result.ToString().TrimEnd();
        }
    }
}
