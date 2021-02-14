using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Common
{
    public static class ExceptionMessages
    {
        public const string NotEnoughFuel = "{0} needs refueling";
        public const string NegativeFuel = "Fuel must be a positive number";
        public const string InvalidVehicleType = "Ivalid vehicle type!";
        public const string UnavailableSpaceInTank = "Cannot fit {0} fuel in the tank";
    }
}
