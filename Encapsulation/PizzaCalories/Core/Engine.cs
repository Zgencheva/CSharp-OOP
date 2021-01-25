using System;
using System.Collections.Generic;
using System.Text;

using PizzaCalories.Models;

namespace PizzaCalories.Core

{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] pizzaData = Console.ReadLine().Split();
            Pizza pizza;
            Dough dough;
            try
            {
                pizza = new Pizza(pizzaData[1]);
                string[] doughData = Console.ReadLine().Split();
                dough = new Dough(doughData[1], doughData[2], int.Parse(doughData[3]));
                pizza.Dough = dough;
                while (true)
                {
                    string[] command = Console.ReadLine().Split();
                    if (command[0] == "END")
                    {
                        break;
                    }


                    Topping current = new Topping(command[1], double.Parse(command[2]));

                    pizza.AddTopping(current);
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }


        }


    }
}
