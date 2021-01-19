using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string DefaultGender = "Female";
        public Kitten(string name, int age, string gender) : base(name, age, DefaultGender)
        {
            //if (gender != "female")
            //{

            //}
        }

        public Kitten(string name, int age) : base(name, age, DefaultGender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
