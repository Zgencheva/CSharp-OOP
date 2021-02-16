using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Common;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        
        public Tiger(string name, double weight, string livingRegion, string bread) : base(name, weight, livingRegion, bread)
        {
        }

        public override double WeightMultiplier => 1;
        public override ICollection<Type> PreferredFoods =>
            new List<Type>() { typeof(Meat) };

        

        public override string IAskForFood()
        {
            return "ROAR!!!";
        }
    }
}
