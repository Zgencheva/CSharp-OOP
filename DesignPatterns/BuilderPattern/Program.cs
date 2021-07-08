using System;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //razdelqme na chasti syzdavaneto na edin obekt
            Console.WriteLine("Hello World!");
            Car car = new Car();
            CarBuilder builder = new CarBuilder();
            //buildPattern
            builder.BuildEngine(car);
            builder.BuildKutiq(car);
            builder.BuildTyres(car);

            //fluent interface
            builder.BuildTyres(car)
                .BuildTyres(car)
                .BuildKutiq(car);
        }
    }
}
