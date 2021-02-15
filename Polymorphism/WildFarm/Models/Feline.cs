using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models
{
    public abstract class Feline : Mammal
    {
        public string Bread { get; private set; }
        protected Feline(string name, double weight, string livingRegion, string bread) : base(name, weight, livingRegion)
        {
            this.Bread = bread;
        }


        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Bread}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
