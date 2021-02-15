using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public abstract class Animal: IEat, IProduceSound
    {
        public string Name { get; private set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public virtual void Eat(Food food)
        {
            throw new NotImplementedException();
        }

        public virtual string IAskForFood()
        {
            return string.Empty;
        }
    }
    
}
