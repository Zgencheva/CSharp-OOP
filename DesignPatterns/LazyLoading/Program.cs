using System;

namespace LazyLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            Lazy<Cart> cart = new Lazy<Cart>();
            Console.WriteLine("In main");
            cart.Value.Balance = 50;
            Console.WriteLine(cart.Value.Balance);
        }
    }
}
