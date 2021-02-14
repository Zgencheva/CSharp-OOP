using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;
using Vehicles.Common;

namespace Vehicles.Factories
{
    public class VehicleFactory
    {
        //factory pattern
        public VehicleFactory()
        {

        }
        public Vehicle CreateVehicle(string vehicleType,
            double fuelQuantity, double fuelConsumption, double tankPerKm)
        {
            Vehicle vehicle = null;
            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankPerKm);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankPerKm);
            }
            else if (vehicleType == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankPerKm);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidVehicleType);
            }
            return vehicle;
        }
    }
}
