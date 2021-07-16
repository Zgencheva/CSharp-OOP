using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private int energy;

        public SleepyBunny(string name)
           : base(name, 50)
        {
        }

        //public override int Energy { get => this.energy; protected set => this.energy = 50; }

        public override void Work()
        {
            this.Energy -= 15;
            if (Energy < 0)
            {
                this.Energy = 0;
            }
        }
    }
}
