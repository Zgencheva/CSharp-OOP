using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : IFerrari
    {
        public string Model => "488-Spider";

        public string Driver { get; set; }

        public string Breaks()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Zadu6avam sA!";
        }

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Breaks()}/{this.Gas()}/{this.Driver}";
        }
    }
}
