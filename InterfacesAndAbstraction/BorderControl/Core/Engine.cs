using System;
using System.Collections.Generic;
using System.Text;

using BorderControl.Contracts;
using BorderControl.Models;

namespace BorderControl.Core

{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            List<IIdentifiable> all = new List<IIdentifiable>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                string[] tokens = command.Split();
                if (tokens.Length == 3)
                {
                    IIdentifiable citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    all.Add(citizen);
                }
                else
                {
                    IIdentifiable robot = new Robot(tokens[0], tokens[1]);
                    all.Add(robot);
                    
                }
            }

            string fakeId = Console.ReadLine();

            for (int i = 0; i < all.Count; i++)
            {
                if (all[i].ID.EndsWith(fakeId))
                {
                    Console.WriteLine(all[i].ID);
                }
            }
        }
    }
}
