using BuilderPattern.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class CarBuilder : ICarBuilder
    {
        public ICarBuilder BuildEngine(Car car)
        {
            car.Engine = "Best engine";
            return this;
        }

        public ICarBuilder BuildKutiq(Car car)
        {
            car.Kutiq = "Best kutiq";
            return this;
        }

        public ICarBuilder BuildTyres(Car car)
        {
            car.Tyres = "Michelin";
            return this;
        }
    }
}
