using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        public MuscleCar(string model, int horsePower, double cubicCentimeters) 
            : base(model, horsePower, cubicCentimeters, 400, 600)
        {
        }

        public override double CubicCentimeters => 5000;
    }
}
