using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Common;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public class Cat : Feline
    {
        private const double Weight_Increasement_per_piece = 0.3;
        public Cat(string name, double weight, string livingRegion, string bread) : base(name, weight, livingRegion, bread)
        {
        }

        public override double WeightMultiplier => 0.3;

        public override ICollection<Type> PreferredFoods =>
            new List<Type>() { typeof(Vegetable), typeof(Meat) };

        
        public override string IAskForFood()
        {
            return "Meow";
        }
    }
}
