using Raiding.Core.Contracts;
using Raiding.Factories;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly BaseHero Druid;
        private readonly BaseHero Paladin;
        private readonly BaseHero Rogue;
        private readonly BaseHero Warrior;
        private readonly BaseHeroFactory baseHeroFactory;
        public Engine()
        {
            this.baseHeroFactory = new BaseHeroFactory();
        }

        public void Run()
        {
            List<BaseHero> raid = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            while (raid.Count < n)
            {
                try
                {
                    raid.Add(CreateHeroByArgs());
                }
                catch (InvalidOperationException ioe)
                {

                    Console.WriteLine(ioe.Message);
                }
            }
                
                
            
            int bossPower = int.Parse(Console.ReadLine());
            if (bossPower > GetTotalRaidPower(raid))
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }

         }

        private BaseHero CreateHeroByArgs()
        {
            string name = Console.ReadLine();
            string type = Console.ReadLine();
            BaseHero currentHero = baseHeroFactory.CreateHero(name, type);
            return currentHero;
        }

        private int GetTotalRaidPower(ICollection<BaseHero> raid)
        {
            int totalPower = 0;
            foreach (BaseHero hero in raid)
            {
                
                Console.WriteLine(hero.CastAbility());
                totalPower += hero.Power;
            }
            return totalPower;
        }
    }
}

