using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    class CTO : Approver
    {
        public override bool HandleRequest(int amount)
        {
            if (amount < 500)
            {
                Console.WriteLine("Eto vzemi ot kompaniqta");
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}
