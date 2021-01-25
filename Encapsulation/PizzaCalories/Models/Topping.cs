using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const string InvalidNameExp = "Cannot place {0} on top of your pizza.";
        private const string WeightRangeEpx = "{0} weight should be in the range [1..50].";
        private const int BaseCaloriesPerGram = 2;

        private string name;
        private double weight;

        public Topping(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.ToLower() == "meat" || value.ToLower() == "veggies" || value.ToLower() == "cheese" || value.ToLower() == "sauce")
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(InvalidNameExp, value));
                }
               
            }
        }

        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (1 <= value && value <= 50)
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(WeightRangeEpx, this.name));
                }

            }
        }

        public double CaloriesPerGram { get => BaseCaloriesPerGram * Modifier(); }

        private double Modifier()
        {
            double result = 1;
            if (this.Name.ToLower() == "meat")
            {
                result = 1.2;
            }
            else if (this.Name.ToLower() == "veggies")
            {
                result = 0.8;
            }
            else if (this.Name.ToLower() == "cheese")
            {
                result = 1.1;
            }
            else if (this.Name.ToLower() == "sauce")
            {
                result = 0.9;
            }
            return result;
        }

        public double TotalCalories()
        {
            double totalCal = this.Weight * CaloriesPerGram;
            return totalCal;
        }

    }
}
