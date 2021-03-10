using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
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
            return this.Name;
        }
    }
}
