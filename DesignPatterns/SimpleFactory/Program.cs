using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnimal lion = AnimalFactory.CreateAnimal("lyvy");

        }
    }
}
