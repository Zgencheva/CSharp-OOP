using System;
using System.Collections.Generic;
using System.Text;

using Cars.Contracts;

namespace Cars.Models
{
    public class Tesla : ICar, IElectricCar

    {
        public Tesla(string model, string color, int batery)
        {
            this.Model = model;
            this.Color = color;
            this.Batery = batery;
        }
        public string Model { get; private set; }

        public string Color { get; private set; }

        public int Batery { get; private set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Color} Seat {this.Model} with {this.Batery} Batteries");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
