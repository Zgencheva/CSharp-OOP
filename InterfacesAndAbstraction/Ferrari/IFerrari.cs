using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public interface IFerrari
    {
        public string Model { get; }
        public string Driver { get; }

        string Breaks();

        string Gas();
    }
}
