using _4.WildFarm.Animals;
using _4.WildFarm.Animals.Birds;
using _4.WildFarm.Animals.Mammals;
using _4.WildFarm.Animals.Mammals.Feline;
using _4.WildFarm.Foods;
using System;
using System.Collections.Generic;

namespace _4.WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                string[] animalTokens = Console.ReadLine().Split();
                if (animalTokens[0] == "End")
                {
                    break;
                }
                string[] foodTokens = Console.ReadLine().Split();
                if (foodTokens[0] == "End")
                {
                    break;
                }

                string animalType = animalTokens[0];
                string animalName = animalTokens[1];
                double animalWeight = double.Parse(animalTokens[2]);

                Animal animal = null;

                if (animalType == "Cat")
                {
                    string animalLivingRegion = animalTokens[3];
                    string animalBreed = animalTokens[4];
                    animal = new Cat(animalName, animalWeight, animalLivingRegion, animalBreed);
                }
                else if (animalType == "Tiger")
                {
                    string animalLivingRegion = animalTokens[3];
                    string animalBreed = animalTokens[4];
                    animal = new Tiger(animalName, animalWeight, animalLivingRegion, animalBreed);
                }
                else if (animalType == "Hen")
                {
                    double animalWingSize = double.Parse(animalTokens[3]);
                    animal = new Hen(animalName, animalWeight, animalWingSize);
                }
                else if (animalType == "Owl")
                {
                    double animalWingSize = double.Parse(animalTokens[3]);
                    animal = new Owl(animalName, animalWeight, animalWingSize);
                }
                else if (animalType == "Mouse")
                {
                    string animalLivingRegion = animalTokens[3];
                    animal = new Mouse(animalName, animalWeight, animalLivingRegion);
                }
                else if (animalType == "Dog")
                {
                    string animalLivingRegion = animalTokens[3];
                    animal = new Dog(animalName, animalWeight, animalLivingRegion);
                }
                animals.Add(animal);

                string foodType = foodTokens[0];
                int foodQuantity = int.Parse(foodTokens[1]);
                Food food = null;
                if (foodType == "Vegetable")
                {
                    food = new Vegetable(foodQuantity);
                }
                else if (foodType == "Fruit")
                {
                    food = new Fruit(foodQuantity);
                }
                else if (foodType == "Seeds")
                {
                    food = new Seeds(foodQuantity);
                }
                else if (foodType == "Meat")
                {
                    food = new Meat(foodQuantity);
                }

                Console.WriteLine(animal.AskForFood());
                try
                {
                    animal.Eat(food);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, animals));
        }
    }
}
