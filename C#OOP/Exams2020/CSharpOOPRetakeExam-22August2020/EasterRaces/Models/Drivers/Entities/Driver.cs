using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int MinLength = 5;

        private string name;

        public Driver(string name)
        {
            Name = name;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinLength)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value,MinLength));
                }
                name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get
            {
                if (!(Car is null))
                {
                    return true;
                }
                return false;
            }
        }

        public void AddCar(ICar car)
        {
            if (car is null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }
            Car = car;
        }

        public void WinRace()
        {
            NumberOfWins += 1;
        }
    }
}
