using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DarkKnight darkNight = new DarkKnight("knighti", 5);
            Console.WriteLine(darkNight);
        }
    }
}
