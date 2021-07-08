using AbstractFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Apple
{
    public class ApplePhone : IMobilePhone
    {
        public int number { get; set; }
    }
}
