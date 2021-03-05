using System;
using System.Collections.Generic;
using System.Text;

namespace _6.FoodShortage
{
    public class Citizen : Person,IBirthable,IIdentifiable
    {
        public Citizen(string name,int age,string id,string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            Food = 0;
        }

        public string Id { get; private set; }

        public string Birthdate { get; private set; }

        public override void BuyFood()
        {
            Food += 10;
        }
    }
}
