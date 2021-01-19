using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal cakePrice  = 5;
        private const double calories = 1000;
        private const double grams = 250;

        //public override decimal Price { get => this.cakePrice; }

        //public override double Calories { get => this.calories; }

        //public override double Grams { get => this.grams; }

        public Cake(string name) : base(name, cakePrice, grams, calories)
        {
        }
    }
}
