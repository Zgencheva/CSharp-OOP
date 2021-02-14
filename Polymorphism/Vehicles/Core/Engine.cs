using System;
using System.Collections.Generic;
using System.Text;

using Vehicles.Core.Contracts;
using Vehicles.Factories;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly VehicleFactory vehicleFactory;
        private readonly Vehicle car;
        private readonly Vehicle truck;
        private readonly Vehicle bus;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }
        
        public void Run()
        {
           Vehicle car = this.ProcessVehicleInfo();
           Vehicle truck = this.ProcessVehicleInfo();
           Vehicle bus = this.ProcessVehicleInfo();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string cmdType = cmdArgs[0];
                string vehicleType = cmdArgs[1];
                //can be liters or kilometers
                double arg = double.Parse(cmdArgs[2]);
                try
                {
                    if (cmdType == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Drive(car, arg);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Drive(truck, arg);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.Drive(bus, arg);
                        }
                    }
                    else if (cmdType == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            this.Refuel(car, arg);
                        }
                        else if (vehicleType == "Truck")
                        {
                            this.Refuel(truck, arg);
                        }
                        else if (vehicleType == "Bus")
                        {
                            this.Refuel(bus, arg);
                        }
                    }
                    else if (cmdType == "DriveEmpty")
                    {
                        this.DriveEmpty(bus, arg);
                    }
                }
                catch (InvalidOperationException ioe)
                {

                    Console.WriteLine(ioe.Message);
                }
                
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private void Drive(Vehicle vehicle, double kilometers)
        {
            Console.WriteLine(vehicle.Drive(kilometers));
            
        }

        private void DriveEmpty(Vehicle bus, double kilometers)
        {
            Console.WriteLine(bus.DriveEmpty(kilometers));

        }

        private void Refuel(Vehicle vehicle, double amount)
        {
            vehicle.Refuel(amount);
        }

        private Vehicle ProcessVehicleInfo()
        {
            string[] vehicleArgs = Console.ReadLine().Split();
            string vehicleType = vehicleArgs[0];
            double fuelQuantity = double.Parse(vehicleArgs[1]);
            double fuelConsumption = double.Parse(vehicleArgs[2]);
            double tankCapacity = double.Parse(vehicleArgs[3]);
            Vehicle currentVehicle = this.vehicleFactory.CreateVehicle
                (vehicleType, fuelQuantity, fuelConsumption, tankCapacity);
            return currentVehicle;  
            
        }
    }
}
