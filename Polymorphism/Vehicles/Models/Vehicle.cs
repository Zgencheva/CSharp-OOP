using System;
using System.Collections.Generic;
using System.Text;

using Vehicles.Models.Contracts;
using Vehicles.Common;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        private const string SUCC_DVIVED_MSG = "{0} travelled {1} km";

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }
        public double FuelQuantity { get; private set; }
        public virtual double FuelConsumption { get; private set; }

        public string Drive(double kilometers)
        {
            double fuelNeeded = kilometers * FuelConsumption;
            if (this.FuelQuantity >= fuelNeeded)
            {
                this.FuelQuantity -= fuelNeeded;
                return string.Format(SUCC_DVIVED_MSG, this.GetType().Name, kilometers);
            }
            else
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.NotEnoughFuel, this.GetType().Name));
            }
        }

        public virtual void Refuel(double amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NegativeFuel);
            }
            this.FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
