using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string [] args)
        {

            Food current = null;
            if (args[0] == "Vegetable")
            {
                current = new Vegetable(int.Parse(args[1]));
            }
            else if (args[0] == "Fruit")
            {
                current = new Fruit(int.Parse(args[1]));
            }
            else if (args[0] == "Meat")
            {
                current = new Meat(int.Parse(args[1]));
            }
            else if (args[0] == "Seeds")
            {
                current = new Seeds(int.Parse(args[1]));
            }
            
            return current;
        }
    }
}
