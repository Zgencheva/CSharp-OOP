using System;

namespace _01Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceOfFlour = double.Parse(Console.ReadLine());
            double priceOfEgg = double.Parse(Console.ReadLine());
            double priceOfApron = double.Parse(Console.ReadLine());

            double additionalApron = Math.Ceiling((double)students * 0.2);
            double totalApron = students + additionalApron;
            double apronTotalPrice = priceOfApron * totalApron;

            double eggsTotalPrice = priceOfEgg * (students * 10);

            double flourNeeded = 0;
            for (int i = 1; i <= students; i++)
            {
                flourNeeded++;
                if (i % 5 ==0)
                {
                    flourNeeded--;
                }
            }
            double totalFlourPrice = flourNeeded * priceOfFlour;

            double totalExpences = apronTotalPrice + eggsTotalPrice + totalFlourPrice;

            if (totalExpences <= budget)

            {
                Console.WriteLine($"Items purchased for {totalExpences:F2}$.");
            }
            else
            {
                Console.WriteLine($"{(totalExpences - budget):F2}$ more needed.");
            }




        }
    }
}
