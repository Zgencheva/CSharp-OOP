using FactoryMethod.Contracts.Factories;
using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which continent you want to play?");
            string continent = Console.ReadLine();
            IAnimalFactory factory = new EuroFactory();
            if (continent == "Africa")
            {
                factory = new AfricaFactory();
            }
            ICarnivore carnivore = factory.GetCarnivore();
        }
    }
}
