using System;

namespace _4.PIzzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] pizzaTokens = Console.ReadLine().Split();
            string[] doughTokens = Console.ReadLine().Split();
            try
            {
                Dough dough = new Dough(doughTokens[1], doughTokens[2], int.Parse(doughTokens[3]));
                Pizza pizza = new Pizza(pizzaTokens[1], dough);

                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] tokens = input.Split();
                    Topping topping = new Topping(tokens[1], int.Parse(tokens[2]));
                    pizza.AddTopping(topping);
                    input = Console.ReadLine();
                }
                Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():f2} Calories.");
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is ArgumentException)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
