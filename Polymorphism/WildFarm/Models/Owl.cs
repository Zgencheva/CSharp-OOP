using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Contracts;
using WildFarm.Common;

namespace WildFarm.Models
{
    public class Owl : Bird
    {
        //private const double Weight_Increasement_per_piece = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplier => 0.25;
        public override ICollection<Type> PreferredFoods =>
            new List<Type>() {typeof(Meat)};

        

        public override string IAskForFood()
        {
            return "Hoot Hoot";
        }
    }
}
