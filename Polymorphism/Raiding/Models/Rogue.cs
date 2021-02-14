using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const string CAST_ABILITY = "{0} - {1} hit for {2} damage";
        public Rogue(string name) : base(name)
        {
        }

        public override int Power => 80;

        public override string CastAbility()
        {
            return string.Format(CAST_ABILITY, this.GetType().Name, this.Name, this.Power);
        }
    }
}
