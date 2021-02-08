using System;

namespace Ferrari
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string driver = Console.ReadLine();
            IFerrari thisFerrari = new Ferrari(driver);
            Console.WriteLine(thisFerrari);
        }
    }
}
