using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : Repository<IBunny>
    {
        

        public override IBunny FindByName(string name)
        {
            return Models.FirstOrDefault(x=> x.Name == name);
        }

        
    }
}
