using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            this.Bag = new Backpack();

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidAstronautName);
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get
            {
                return this.oxygen;
            }
            protected set
            {
                if (value <0)
                {
                    throw new ArgumentException(Utilities.Messages.ExceptionMessages.InvalidOxygen);
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath { get; private set; }

        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            this.Oxygen -= 10;
            if (this.Oxygen <0)
            {
                this.Oxygen = 0;
            }
        }

        public override string ToString()
        {
            string bagResult = $"none\r\n";
            if (this.Bag.Items.Count != 0)
            {
                bagResult = $"{string.Join(", ", Bag.Items)}\r\n";
            }
            return $"Name: {this.Name}\r\n" +
                $"Oxygen: {this.Oxygen}\r\n" +
              $"Bag items: " + bagResult;
               
        }
    }
}
