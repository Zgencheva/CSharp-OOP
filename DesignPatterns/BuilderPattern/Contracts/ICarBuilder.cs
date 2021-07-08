using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern.Contracts
{
    public interface ICarBuilder
    {
        ICarBuilder BuildTyres(Car car);
        ICarBuilder BuildEngine(Car car);
        ICarBuilder BuildKutiq(Car car);
    }
}
