using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Common;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        private const double Weight_Increasement_per_piece = 0.4;


        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplier => 0.4;

        public override ICollection<Type> PreferredFoods =>
            new List<Type>() { typeof(Meat) };

        public override string IAskForFood()
        {
            return $"Woof!";
        }
    }
}
