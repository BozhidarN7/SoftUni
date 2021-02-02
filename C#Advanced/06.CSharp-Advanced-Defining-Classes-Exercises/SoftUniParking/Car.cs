using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            string result = $"Make: {Make}" + Environment.NewLine;
            result += $"Model: {Model}" + Environment.NewLine;
            result += $"HorsePower: {HorsePower}" + Environment.NewLine;
            result += $"RegistrationNumber: {RegistrationNumber}";
            return result;
        }
    }
}
