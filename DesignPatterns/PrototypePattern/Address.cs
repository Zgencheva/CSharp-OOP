using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    public class Address : ICloneable
    {
        public City City { get; set; }
        public Country Country { get; set; }

        public string Street { get; set; }

        public object Clone()
        {
            //return this.MemberwiseClone();
            //return new Address()
            //{
            //    City = City,
            //    Country = Country,
            //    Street = Street
            //};
            var clone = (Address)this.MemberwiseClone();
            clone.City = (City)City.Clone();
            clone.Country = (Country)Country.Clone();

            return clone;
        }

        public override string ToString()
        {
            return $"Country {Country.Name}, City {City.Name}, Street {Street}";
        }
    }
}
