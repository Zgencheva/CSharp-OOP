using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting
{
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public string WhatsMyName()
        {
          return  $"My name is {this.Name}";
        }
    }
}
