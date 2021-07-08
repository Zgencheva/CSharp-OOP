using FactoryMethodAndAbstractFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    interface IAnimalFactory
    {
        public ICarnivore GetCarnivore();

        public IVegan GetVegan();

        public INasekomo GetNasekomo();
    }
}
