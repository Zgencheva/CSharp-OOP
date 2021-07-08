using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Approver teamLed = new TeamLeadApprover();
            Approver cto = new CTO();

            teamLed.SetNext(cto);

            teamLed.HandleRequest(3);
            teamLed.HandleRequest(3);
            teamLed.HandleRequest(5000);
        }
        }
    }
}
