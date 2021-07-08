using AbstractFactory.Apple;
using AbstractFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Factories
{
    class AppleFactory : ITechnologyAbstractFactory
    {
        public IMobilePhone CreatePhone()
        {
            return new ApplePhone();
        }

        public ITablet CreateTablet()
        {
            return new AppleTablet();
        }
    }
}
