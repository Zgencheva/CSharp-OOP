using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMilliliters = 50;
        private const decimal CoffeePrice = 3.50M;
        public double Caffeine  { get; set; }

        //public override double Milliliters { get => this.CoffeeMilliliters; }

        //public override decimal Price { get => this.CoffeePrice;}
        public Coffee(string name, double caffeine) : base(name, CoffeePrice, CoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public Coffee(string name) : base(name, CoffeePrice, CoffeeMilliliters)
        {
            
        }


    }
}
