using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        string make;
        string model;
        int year;

        public int Year { get => year; set => year = value; }
        public string Model { get => model; set => model = value; }
        public string Make { get => make; set => make = value; }
    }
}
