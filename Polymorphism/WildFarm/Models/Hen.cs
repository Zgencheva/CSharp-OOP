using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public class Hen : Bird, IEat, IProduceSound
    {
        private const double Weight_Increasement_per_piece = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            this.Weight += food.Quantity * Weight_Increasement_per_piece;
            this.FoodEaten += food.Quantity;
        }

        public override string IAskForFood()
        {
            return "Cluck";
        }
    }
}
