using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Common;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public abstract class Animal: IAnimal, IEat, IProduceSound
    {
        public string Name { get; private set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public abstract double WeightMultiplier { get; }
            
        //this will hold type of preferred foods
        public abstract ICollection<Type> PreferredFoods { get; }

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        

        public abstract string IAskForFood();

        public void Eat(IFood food)
        {
            if (!this.PreferredFoods.Contains(food.GetType()))
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.InvalidFoodType, this.GetType().Name, 
                    food.GetType().Name));
            }
            else
            {
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * this.WeightMultiplier;
            }
        }
    }
    
}
