using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Contracts;
using WildFarm.Common;

namespace WildFarm.Models
{
    public class Owl : Bird, IEat, IProduceSound
    {
        private const double Weight_Increasement_per_piece = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                this.Weight += food.Quantity * Weight_Increasement_per_piece;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFoodType, this.GetType().Name, food.GetType().Name));
            }
        }

        public override string IAskForFood()
        {
            return "Hoot Hoot";
        }
    }
}
