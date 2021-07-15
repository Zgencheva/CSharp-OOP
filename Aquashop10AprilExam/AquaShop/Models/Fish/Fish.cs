using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private decimal price;
        protected Fish(string name, string species, decimal price)
        {
            this.Name = name;
            this.Species = species;
            this.Price = price;
        }
        public string Name
        {
            //TODO: names are unique
            get 
            {
                return this.name;    
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    //"Fish name cannot be null or empty."
                    throw new ArgumentException(ExceptionMessages.InvalidFishName);
                }
                this.name = value;
            }
        }

        public string Species
        {
            get
            {
                return this.species;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    //"Fish species cannot be null or empty."
                    throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
                }
                this.species = value;
            }
        }

        public virtual int Size { get; protected set; }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                if (value <=0)
                {
                    //"Fish price cannot be below or equal to 0."
                    throw new ArgumentException(ExceptionMessages.InvalidFishPrice);
                }
                this.price = value;
            }

        }

       
        public abstract void Eat();

        public override string ToString()
        {
            return this.Name;
        }

    }
}
