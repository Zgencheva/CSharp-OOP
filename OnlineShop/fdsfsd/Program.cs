using System;

namespace MidExam
{
    class Program
    {
        static void Main(string[] args)
        {

            double neededExpirience = double.Parse(Console.ReadLine()); // нужен опит, нужно ние да отключи резервоара
            int countOfBattles = int.Parse(Console.ReadLine()); // брой битки 
            double earnedBattles = 0;// спечелени битки, опитност
            int battlesNeeededToCollectExp = 0;
            for (int i = 1; i <= countOfBattles; i++)
            {
                double expEarnedPerBattles = double.Parse(Console.ReadLine());
                
                if (i % 3 == 0)
                {
                    expEarnedPerBattles += (0.15 * expEarnedPerBattles);
                }
                if (i % 5 == 0)
                {
                    expEarnedPerBattles -= (0.10 * expEarnedPerBattles);
                }
                if (i % 15 == 0)
                {
                    expEarnedPerBattles += (0.05 * expEarnedPerBattles);
                }
                earnedBattles += expEarnedPerBattles;
                battlesNeeededToCollectExp++;
                if (earnedBattles >= neededExpirience)
                {
                    
                    break;
                }
            }
            if (earnedBattles >= neededExpirience)
            {
                Console.WriteLine($"Player successfully collected his needed expеrience for {battlesNeeededToCollectExp} battles.");
               
            }
            else 
            {
                Console.WriteLine($"Player was not able to collect the needed expеrience, {(neededExpirience - earnedBattles):f2} more needed.");
            }
        }
    }
}
