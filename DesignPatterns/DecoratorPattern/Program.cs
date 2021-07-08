using System;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IPaymentSystem payment = new PaymentSystemDecorator(
                new PayPalSystem()
                );
            payment.LoanMoney("Bai ti gosho", "Bai ti Pesho", 3);
            payment.PayMoney("Bai ti PEsho", "Bai ti Gosho", 43);
            payment.LoanMoney("Bai ti gosho", "Bai ti Pesho", 4333);


        }
    }
}
