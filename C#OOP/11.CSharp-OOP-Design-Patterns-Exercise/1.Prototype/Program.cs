using System;

namespace _1.Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            SandwichMenu menu = new SandwichMenu();

            menu["BLT"] = new Sandwich("Wheat", "Bacon", "", "lettcue, Tomato");
            menu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly");
            menu["Turkey"] = new Sandwich("Rye", "Turkey", "", "lettcue, Onion, Tomato");

            menu["LoadedBLT"] = new Sandwich("Wheat", "Turkey,Bacon", "American", "lettuce, Tomato,Onion,Olives");
            menu["ThreeMeatCombo"] = new Sandwich("Rye", "Turkey, Ham, Salami", "Provolone", "Lettuce, Onion");
            menu["Vegetarian"] = new Sandwich("What", "", "", "Letuce, Onion, Tomato, Olives, Spinach");

            Sandwich sandwich1 = menu["BLT"].Clone() as Sandwich;
            Sandwich sandwich2 = menu["ThreeMeatCombo"].Clone() as Sandwich;
            Sandwich sandwich3 = menu["Vegetarian"].Clone() as Sandwich;

            sandwich3.AddVeggies("Cucumber");

            Sandwich burger = new Sandwich("Wheat", "Turkey", "American", "Lettuce, Tomato");
            Sandwich burgerCopy = burger.Clone() as Sandwich;
            burger.AddVeggies("Cucumber");
            ;
        }
    }
}
