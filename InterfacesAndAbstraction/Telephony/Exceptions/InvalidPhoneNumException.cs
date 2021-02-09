using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Exceptions
{
    public class InvalidPhoneNumException : Exception
    {
        private const string INVALID_PHN_EXCEPTION_MSG = "Invalid number!";

        public InvalidPhoneNumException()
            : base(INVALID_PHN_EXCEPTION_MSG)
        {

        }
    }
}
