using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : Repository<IEgg>
    {
        public override IEgg FindByName(string name)
        {
            return Models.FirstOrDefault(x => x.Name == name);
        }
    }
}
