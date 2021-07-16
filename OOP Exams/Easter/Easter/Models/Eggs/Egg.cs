using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private string name;
        private int energyReuired;

        public Egg(string name, int energyReq)
        {
            this.Name = name;
            this.EnergyRequired = energyReq;
        }
        public string Name
        {
            get 
            {
                return this.name;
            }
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }
                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get
            {
                return this.energyReuired;
            }
            private set
            {
                if (value <0)
                {
                    this.energyReuired = 0;
                }
                else
                {
                    this.energyReuired = value;
                }
            }
        }

        public void GetColored()
        {
            this.EnergyRequired -= 10;
            if (this.EnergyRequired <0)
            {
                this.EnergyRequired = 0;
            }
        }

        public bool IsDone()
        {
            
            if (this.EnergyRequired == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
