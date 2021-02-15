using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Common;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public class Tiger : Feline, IEat, IProduceSound
    {
        private const double Weight_Increasement_per_piece = 1;
        public Tiger(string name, double weight, string livingRegion, string bread) : base(name, weight, livingRegion, bread)
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
            return "ROAR!!!";
        }
    }
}
