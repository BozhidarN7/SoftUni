using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double DefaultCubicCentimetres = 3000;
        private const int MinHorsePower = 250;
        private const int MaxHorsePower = 450;

        public SportsCar(string model, int horsePower)
            : base(model, horsePower, DefaultCubicCentimetres, MinHorsePower, MaxHorsePower)
        {

        }
    }
}
