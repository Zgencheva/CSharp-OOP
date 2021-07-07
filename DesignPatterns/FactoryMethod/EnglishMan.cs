using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    public class EnglishMan : ICarnivore
    {
        public string AnimalsThatIEat { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
