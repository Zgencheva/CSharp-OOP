using AbstractFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Apple
{
    public class AppleTablet : ITablet
    {
        public string OS { get; set; }
    }
}
