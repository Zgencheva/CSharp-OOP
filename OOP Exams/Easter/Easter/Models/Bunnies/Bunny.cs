using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
  
        private readonly List<IDye> dyes;
        //private int energy;
        protected Bunny(string name, int energy)
           
        {
            this.Name = name;
            this.dyes = new List<IDye>();
            this.Energy = energy;
            
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }
                this.name = value;
            }
        }

        public int Energy { get; protected set; }

        public ICollection<IDye> Dyes => this.dyes;

        public void AddDye(IDye dye)
        {
            //TODO: Check if dye is null!
            dyes.Add(dye);
        }

        public abstract void Work();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Energy: {this.Energy}");
            sb.AppendLine($"Dyes: {this.Dyes.Count(x=> x.IsFinished()==false)} not finished");
            return sb.ToString().TrimEnd();
        }


    }
}
