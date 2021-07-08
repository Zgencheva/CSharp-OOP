using System;
using System.Collections.Generic;
using System.Text;

namespace LazyLoading
{
    public class Cart
    {
        public Cart()
        {
            Console.WriteLine("Initialized");
        }
        public int Balance { get; set; }
    }
}
