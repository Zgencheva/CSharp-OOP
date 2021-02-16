using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Contracts
{
    public interface IEat
    {
        public void Eat(IFood food);

        int FoodEaten { get; }

        double WeightMultiplier { get; }

        ICollection<Type> PreferredFoods { get; }


    }
}
