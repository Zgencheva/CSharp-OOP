﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite2.Contracts
{
    public interface ISoldier
    {
        public int Id { get; }

        public string FirstName { get; }

        public string LastName { get;}
    }
}
