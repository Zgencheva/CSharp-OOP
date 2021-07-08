using System;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Country country = new Country() { Name = "Üzbekistan"};
            City city = new City() { Name = "UzbekistanCity" };
            Address adress = new Address() { Street = "Uzbeki 29"};
            adress.City = city;
            adress.Country = country;

            Address prototypeAdress = (Address)adress.Clone();
            prototypeAdress.Street = "Uzbeki 31";

            Console.WriteLine(adress);
            Console.WriteLine(prototypeAdress);
                
        }
    }
}
