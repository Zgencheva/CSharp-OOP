using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.BakedFoods
{
    public abstract class BakedFood : IBakedFood
    {
        private string name;
        private int portion;
        private decimal price;
        private BakedFoodType type;

        protected BakedFood(string name, int portion, decimal price)
        {
            this.Name = name;
            this.Price = price;
            this.Portion = portion;
        }
        //protected BakedFood(string name, int portion, decimal price)
        //    :this(name, price)
        //{

        //    this.Portion = portion;

        //}
        public string Name {

            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidName);
                }
                this.name = value;
            }
        }

        public int Portion
        {
            get
            {
                return this.portion;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPortion);
                }
                this.portion = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidPrice);
                }
                this.price = value;
            }
        }

        public override string ToString()
        {

            return $"{this.Name}: {this.Portion}g - {this.Price:F2}";
        }
    }
}
