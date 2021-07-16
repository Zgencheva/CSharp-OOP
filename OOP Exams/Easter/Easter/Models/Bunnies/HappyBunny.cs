using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {

        private int energy;

        public HappyBunny(string name) 
            : base(name, 100)
        {
        }

        //public override int Energy { get => this.energy; protected set => this.energy =100; }

        public override void Work()
        {
            this.Energy -= 10;
            if (Energy < 0)
            {
                this.Energy = 0;
            }
        }
    }
}
