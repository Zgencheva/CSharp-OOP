using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Common;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public class Mouse : Mammal, IEat, IProduceSound
    {
        private const double Weight_Increasement_per_piece = 0.1;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable || food is Fruit)
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
            return "Squeak";
        }
    }
}
