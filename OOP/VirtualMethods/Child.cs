using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualMethods
{
    class Child : Person
    {
        public override void Sleep()
        {
            Console.WriteLine("not sleepig at all"); ;
        }
    }
}
