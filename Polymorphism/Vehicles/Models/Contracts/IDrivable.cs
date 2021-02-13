using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models.Contracts
{
    public interface IDrivable
    {
        string Drive(double kilometers);
    }
}
