using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualMethods
{
    class Robot : Person
    {
        public override void Sleep()
        {
            throw new ArgumentException();
        }
    }
}
