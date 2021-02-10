using System;
using System.Collections.Generic;
using System.Text;

using MilitaryElite2.Models;
using MilitaryElite2.Contracts;

namespace MilitaryElite2.Core
{
    public class Engine
    {
        public Engine()
        {

        }
        public void Run()
        {
            //List<Private> privates = new List<Private>();
            List<ISoldier> soldiers = new List<ISoldier>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;

                }
                try
                {
                    string[] tokens = command.Split();
                    if (tokens[0] == "Private")
                    {
                        Private current = new Private(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]));
                        soldiers.Add(current);
                    }
                    else if (tokens[0] == "LieutenantGeneral")
                    {
                        LieutenantGeneral current = new LieutenantGeneral(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]));
                        for (int i = 5; i < tokens.Length; i++)
                        {
                            current.AddPriveteToList(soldiers, int.Parse(tokens[i]));
                        }
                        soldiers.Add(current);
                    }
                    else if (tokens[0] == "Engineer")
                    {
                        Engineer current = new Engineer(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]), tokens[5]);
                        soldiers.Add(current);
                        for (int i = 6; i < tokens.Length; i += 2)
                        {
                            Repair repairPArt = new Repair(tokens[i], int.Parse(tokens[i + 1]));
                            current.AddRepair(repairPArt);
                        }
                    }
                    else if (tokens[0] == "Commando")
                    {
                        Commando current = new Commando(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]), tokens[5]);
                        soldiers.Add(current);

                        for (int i = 6; i < tokens.Length; i += 2)
                        {

                            try
                            {
                                Mission currentMission = new Mission(tokens[i], tokens[i + 1]);
                                current.AddMission(currentMission);
                            }
                            catch (ArgumentException ae)
                            {


                            }



                        }
                    }
                    else if (tokens[0] == "Spy")
                    {
                        Spy current = new Spy(int.Parse(tokens[1]), tokens[2], tokens[3], int.Parse(tokens[4]));
                        soldiers.Add(current);
                    }
                }
                catch (ArgumentException ae)
                {

                    continue;
                }
                

            }
            foreach (var item in soldiers)
            {
                Console.WriteLine(item);
            }

        }
    }
}
