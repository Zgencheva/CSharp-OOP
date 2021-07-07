using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Contracts.Factories
{
    public class EuroFactory : IAnimalFactory
    {
        public ICarnivore GetCarnivore()
        {
            throw new NotImplementedException();
        }
    }
}
