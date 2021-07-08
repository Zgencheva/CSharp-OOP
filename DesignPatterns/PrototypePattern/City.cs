using System;

namespace PrototypePattern
{
    public class City : ICloneable
    {
        public string Name { get; set; }
        public Country Country { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}