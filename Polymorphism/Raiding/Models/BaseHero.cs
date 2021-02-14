using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class BaseHero
    {
        private const string CAST_ABILITY_STRING = "{0} - {1} healed for {2}";
        public string Name { get; private set; }
        public virtual int Power { get; private set; }

        public BaseHero(string name)
        {
            this.Name = name;
            
        }

        public virtual string CastAbility()
        {
            return string.Format(CAST_ABILITY_STRING, this.GetType().Name, this.Name, this.Power);
        }
    }
}
