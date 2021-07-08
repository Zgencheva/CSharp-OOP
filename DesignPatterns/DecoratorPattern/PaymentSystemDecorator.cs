using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    class PaymentSystemDecorator : IPaymentSystem
    {
        private IPaymentSystem paymentSystem;

        public PaymentSystemDecorator(IPaymentSystem system)
        {
            this.paymentSystem = system;
        }
        public void LoanMoney(string from, string to, int amount)
        {
            Console.WriteLine("Decorated payment system and loggin in our system loans");
            paymentSystem.LoanMoney(from, to, amount);
        }

        public void PayMoney(string from, string to, int amount)
        {
            Console.WriteLine("Decorated payment system and loggin in our system payments");
            paymentSystem.PayMoney(from, to, amount);
        }
    }
}
