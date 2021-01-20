using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string DefaultGender = "Male";

        //public override string Gender
        //{
        //    get
        //    {
        //        return base.Gender;
        //    }

        //    set
        //    {
        //        if (value != "Male")
        //        {
        //            throw new ArgumentException("Invalid input!");
        //        }
        //        base.Gender = "Male";
        //    }


        //}

        public Tomcat(string name, int age, string gender) : base(name, age, DefaultGender)
        {

        }

        public Tomcat(string name, int age) : base(name, age, DefaultGender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
