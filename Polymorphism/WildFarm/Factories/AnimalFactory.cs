using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models;

namespace WildFarm.Factories
{
    public class AnimalFactory
    {
        public Animal CreateAnimal(string[] args)
        {
            Animal current = null;

            if (args.Length == 5)
            {
                if (args[0] == "Cat")
                {
                    current = new Cat(args[1], double.Parse(args[2]), args[3], args[4]) ;
                }
                else if (args[0] == "Tiger")
                {
                    current = new Tiger(args[1], double.Parse(args[2]), args[3], args[4]);
                }
            }
            else if (args.Length == 4)
            {
                if (args[0] == "Owl" || args[0] == "Hen")
                {
                    if (args[0] == "Owl")
                    {
                        current = new Owl(args[1], double.Parse(args[2]), double.Parse(args[3]));
                    } 
                    else if (args[0] == "Hen")
                    {
                        current = new Hen(args[1], double.Parse(args[2]), double.Parse(args[3]));
                    }
                }
                else if (args[0] == "Mouse" || args[0] == "Dog")
                {
                    if (args[0] == "Mouse")
                    {
                        current = new Mouse(args[1], double.Parse(args[2]), args[3]);
                    }
                    else if (args[0] == "Dog")
                    {
                        current = new Dog(args[1], double.Parse(args[2]), args[3]);
                    }
                }

            }

            return current;
        }
    }
}
