using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Common;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        private const double Weight_Increasement_per_piece = 0.1;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => 0.1;

        public override ICollection<Type> PreferredFoods =>
            new List<Type>() { typeof(Vegetable), typeof(Fruit) }; 

        public override string IAskForFood()
        {
            return "Squeak";
        }
    }
}
