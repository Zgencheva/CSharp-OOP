using System;

namespace GiftCompositePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            LeafClass singleGift = new LeafClass("single", 50);
            CompositeGift compositeBox = new CompositeGift("common", 10);
            LeafClass singleGift2 = new LeafClass("single2", 80);

            compositeBox.Add(singleGift);
            compositeBox.Add(singleGift2);

            Console.WriteLine(compositeBox.CalculatePrice());
        }
    }
}
