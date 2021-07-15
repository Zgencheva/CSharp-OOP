using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        public SportsCar(string model, int horsePower, double cubicCentimeters)
            : base(model, horsePower, cubicCentimeters, 250, 450)
        {
        }

        public override double CubicCentimeters => 3000;
    }
}
