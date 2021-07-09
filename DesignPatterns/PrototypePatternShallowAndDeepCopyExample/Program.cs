using System;

namespace PrototypePatternShallowAndDeepCopyExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Drink drink = new Drink("Coke");

            Sandwich sandwichBase = new Sandwich("bb", "mm", "vegg", drink);
            Sandwich sandShallowClone = sandwichBase.ShallowCopy();
            Sandwich sandDeepCopy = sandwichBase.DeepCopy();
           
            Console.WriteLine(sandwichBase);
            Console.WriteLine(sandShallowClone);
            Console.WriteLine(sandDeepCopy);
            //shallow copy changes the drink name of the original sandwich!
            //Deep copy remains the same!
            sandShallowClone.Drink.Name = "test";
            Console.WriteLine(sandwichBase);
            Console.WriteLine(sandShallowClone);
            Console.WriteLine(sandDeepCopy);



        }
    }
}
