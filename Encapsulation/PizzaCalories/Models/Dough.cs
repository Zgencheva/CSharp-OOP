using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const string InvalidTypeDoughExp = "Invalid type of dough.";
        private const string WeightRangeExp = "Dough weight should be in the range [1..200].";

        private const int BaseCaloriesPerGram = 2;
        //flour type, which can be white or wholegrain
        //baking technique, which can be crispy, chewy or homemade
        //weight in grams
        private string flourType;
        private string bakingTechnique;
        private int weight;

        //private double flourTypeModifier = 1;
        //private double bakingTeqModifier = 1;;

        public Dough()
        {

        }
        public Dough(string flourType, string bakingTeq, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTeq;
            this.Weight = weight;
        }
        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            private set
            {
                if (value.ToLower() == "white" || value.ToLower() == "wholegrain")
                {
                    this.flourType = value;

                }
                else
                {
                    throw new ArgumentException(InvalidTypeDoughExp);
                }

            }

        }

        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
            private set
            {
                if (value.ToLower() == "crispy" || value.ToLower() == "chewy" || value.ToLower() == "homemade")
                {

                    this.bakingTechnique = value;
                }
                else
                {
                    throw new ArgumentException(InvalidTypeDoughExp);
                }

            }
        }

        public int Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (1 <= value && value <= 200)
                {
                    this.weight = value;
                }
                else
                {
                    throw new ArgumentException(WeightRangeExp);
                }

            }

        }

        public double CalorierPerGram
        {
            get
            {
                return BaseCaloriesPerGram * FlourTypeModifier() * BakingTeqModifier();
            }
            
        }

        private double FlourTypeModifier()
        {
            double flourModifier = 1;
            if (this.FlourType.ToLower() == "white")
            {
                flourModifier = 1.5;
            }
            else if (this.FlourType.ToLower() == "wholegrain")
            {
                flourModifier = 1;
            }
            return flourModifier;
        }

        private double BakingTeqModifier()
        {
            double bakingModifier = 1;
            if (this.BakingTechnique.ToLower() == "crispy")
            {
                bakingModifier = 0.9;
            }
            else if (this.BakingTechnique.ToLower() == "chewy")
            {
                bakingModifier = 1.1;
            }
            else if (this.BakingTechnique.ToLower() == "homemade")
            {
                bakingModifier = 1;

            }
            return bakingModifier;
        }
        //100 grams will have (2 * 100) * 1.5 * 1.1 = 330.00 
        public double TotalCalories()
        {
            double totalCal = this.Weight * CalorierPerGram;
            return totalCal;
        }
    }
}
