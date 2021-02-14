using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const string CAST_ABILITY = "{0} - {1} hit for {2} damage";
        public Warrior(string name) : base(name)
        {
        }

        public override int Power => 100;

        public override string CastAbility()
        {
            return string.Format(CAST_ABILITY, this.GetType().Name, this.Name, this.Power);
        }
    }
}
