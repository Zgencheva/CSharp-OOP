using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Contracts
{
    public interface ITechnologyAbstractFactory
    {
        IMobilePhone CreatePhone();
        ITablet CreateTablet();
    }
}
