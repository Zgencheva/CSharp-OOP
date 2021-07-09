using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePatternShallowAndDeepCopyExample
{
    public class Drink
    {
        public string Name { get; set; }
        public Drink(string name)
        {
            this.Name = name;
        }
    }
}
