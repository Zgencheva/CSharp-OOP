﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string vIN, int horsePower)
            : base(make, model, vIN, horsePower, 65, 7.5)
        {
        }

        public override void Drive()
        {
            base.Drive();
            
            this.HorsePower = (int)Math.Round(this.HorsePower - this.HorsePower * 0.03);
        }
    }
}
