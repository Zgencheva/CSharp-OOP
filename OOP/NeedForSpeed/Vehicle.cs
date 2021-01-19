using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public int HorsePower  { get; set; }
        public double Fuel  { get; set; }

        private double DefaultFuelConsumption = 1.25;

        public virtual double FuelConsumption
        {
            get 
            {
                return this.DefaultFuelConsumption;
            }
        }

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public virtual void Drive(double kilometers)
        {
            double currentConsumption = kilometers * FuelConsumption;
            if (Fuel - currentConsumption >= 0)
            {
                this.Fuel -= currentConsumption;
            }
            else
            {
                throw new ArgumentException("you cannot drive the kilometers");
            }
            
            
        }
    }
}
