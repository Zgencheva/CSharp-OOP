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
        private const double FUEL_CONSUMPTION_EMPTY_BUS = -1.4;

        //private double tankCapacity;
        //private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelConsumption = fuelConsumption;
            //this.FuelQuantity = fuelQuantity;
            this.TankCapacity = tankCapacity;
            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }

        }
        public double FuelQuantity { get; set; }
        //    get
        //    {
        //        return this.fuelQuantity;
        //    }

        //    set
        //    {
        //        if (value >= this.TankCapacity)
        //        {
        //            this.fuelQuantity = 0;
        //        }
                
        //            this.fuelQuantity = value;
                
                
        //    }
        //}
        public virtual double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }
        

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

        public string DriveEmpty(double kilometers)
        {
            double fuelNeeded = kilometers * (FuelConsumption + FUEL_CONSUMPTION_EMPTY_BUS);
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
            if (amount <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NegativeFuel);
            }
            if (this.FuelQuantity + amount > this.TankCapacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnavailableSpaceInTank, amount));
            }
            this.FuelQuantity += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
