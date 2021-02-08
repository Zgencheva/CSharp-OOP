using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        private string number;
        public string Number 
        {
            get
            {
                return this.number;
            }
            set
            {
                
                this.number = value;
            }
        }

        public string Browse => throw new NotImplementedException();
    }
}
