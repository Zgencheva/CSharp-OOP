using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    interface IAnimalFactory
    {
        public ICarnivore GetCarnivore();
    }
}
