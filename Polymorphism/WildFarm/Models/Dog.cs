using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Common;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public class Dog : Mammal, IEat, IProduceSound
    {
        private const double Weight_Increasement_per_piece = 0.4;


        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void  Eat(Food food)
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
            return $"Woof!";
        }
    }
}
