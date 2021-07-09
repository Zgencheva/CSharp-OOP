using StrategyPattern.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string sortType = Console.ReadLine();

            Type strategyType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => typeof(ISortingStrategy).IsAssignableFrom(x)
                && x.Name.StartsWith(sortType)
                ).FirstOrDefault();

            ISortingStrategy strategy = (ISortingStrategy)Activator.CreateInstance(strategyType);

            Sorter sorter = new Sorter(strategy);
            sorter.Sort(new List<int> { 1,3,5,6,8});

        }
    }
}
