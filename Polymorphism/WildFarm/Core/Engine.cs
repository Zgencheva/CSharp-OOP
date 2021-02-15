using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Core.Contracts;
using WildFarm.Factories;
using WildFarm.Models;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        //private readonly Food fruit;
        //private readonly Food vegetable;
        //private readonly Food seeds;
        //private readonly Food meat;
        //private readonly Animal owl;
        //private readonly Animal hen;
        //private readonly Animal mouse;
        //private readonly Animal dog;
        //private readonly Animal cat;
        //private readonly Animal tiger;
        private readonly FoodFactory foodFactory;
        private readonly AnimalFactory animalFactory;
        public Engine()
        {
            this.foodFactory = new FoodFactory();
            this.animalFactory = new AnimalFactory();
        }
        public void Run()
        {
            List<Animal> allAnimals = new List<Animal>();
            while (true)
            {
                string[] animalArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (animalArgs[0] == "End")
                {
                    break;
                }

                allAnimals.Add(CreateAnimalByArgs(animalArgs));




            }
            foreach (Animal animal in allAnimals)
            {
                Console.WriteLine(animal);
            }
        }

        private Animal CreateAnimalByArgs(string[] animalArgs)
        {

            Animal current = animalFactory.CreateAnimal(animalArgs);
            Console.WriteLine(current.IAskForFood());
            try
            {
                current.Eat(CreateFoodByArgs());
            }
            catch (InvalidOperationException ioe)
            {

                Console.WriteLine(ioe.Message);
            }
            
            
            return current;
        }

        private Food CreateFoodByArgs()
        {
            string[] foodArgs = Console.ReadLine().Split();
            Food current = foodFactory.CreateFood(foodArgs);
            return current;
        }


    }
}
