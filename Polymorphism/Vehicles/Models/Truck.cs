using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCR = 1.6;
        private const double REFUEL_SUCC_COEFF = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => 
            base.FuelConsumption + FUEL_CONSUMPTION_INCR;

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NegativeFuel);
            }
            if (this.FuelQuantity + amount > this.TankCapacity)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnavailableSpaceInTank, amount));
            }
            base.FuelQuantity += amount * REFUEL_SUCC_COEFF;
        }
    }
}
