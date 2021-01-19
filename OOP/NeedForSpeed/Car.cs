using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private int DefaultFuelConsumption = 3;

        public override double FuelConsumption { get => this.DefaultFuelConsumption; }

        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }
    }
}
