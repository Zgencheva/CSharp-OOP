using System;

using FootballTeamGenerator.Core;
using FootballTeamGenerator.Models;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
