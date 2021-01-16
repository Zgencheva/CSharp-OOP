using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualMethods
{
    class Person
    {
        public virtual void Sleep()
        {
            Console.WriteLine("sleeping well");
        }
    }
}
