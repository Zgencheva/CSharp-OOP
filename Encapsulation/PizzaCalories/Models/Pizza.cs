using System;
using System.Collections.Generic;
using System.Text;



namespace PizzaCalories.Models
{
    public class Pizza
    {
        private const string NameValidationExpMsg = "Pizza name should be between 1 and 15 symbols.";
        private const string ToppingsCountExpMsg = "Number of toppings should be in range [0..10].";

        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza()
        {

        }
        public Pizza(string name)
        {
            this.Name = name;
            
            this.Toppings = new List<Topping>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (1 <= value.Length && value.Length <= 15)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException(NameValidationExpMsg);
                }


            }
        }

        public Dough Dough 
        { 
            get
            {
                return this.dough;
            }
            set
            {
                this.dough = value;
            } 
        }

        private List<Topping> Toppings
        {
            get
            {
                return this.toppings;
            }
            set
            {
                this.toppings = value;
            }
        }

        public int NumberOfToppings { get => this.Toppings.Count; }

        public double TotalCalories { get => this.TotalCaloriesPrivate(); }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count < 10)
            {
                this.Toppings.Add(topping);
            }
            else
            {
                throw new ArgumentException(ToppingsCountExpMsg);
            }
            
        }

        private double TotalCaloriesPrivate()
        {
            double result = 0;
            foreach (var item in this.Toppings)
            {
                result += item.TotalCalories();
            }
            result += this.Dough.TotalCalories();
            return result;
        }




    }
}
