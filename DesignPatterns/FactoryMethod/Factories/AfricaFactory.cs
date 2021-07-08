using FactoryMethodAndAbstractFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod.Contracts.Factories
{
    public class AfricaFactory : IAnimalFactory
    {
        public ICarnivore GetCarnivore()
        {
            return new Lion();
        }

        public INasekomo GetNasekomo()
        {
            throw new NotImplementedException();
        }

        public IVegan GetVegan()
        {
            return new EnglishMan();
        }
    }
}
