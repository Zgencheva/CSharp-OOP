using System;
using System.Collections.Generic;
using System.Text;

using FootballTeamGenerator.Models;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();
            while (true)
            {
                string[] command = Console.ReadLine().Split(";");
                if (command[0] == "END")
                {
                    break;
                }

                try
                {
                    if (command[0] == "Team")
                    {
                        Team current = new Team(command[1]);
                        teams.Add(command[1], current);
                    }
                    else if (command[0] == "Add")
                    {
                        string teamName = command[1];
                        string PlayerName = command[2];

                        if (!teams.ContainsKey(teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            Team current = teams[teamName];
                            current.AddPlayer(PlayerName, int.Parse(command[3]), int.Parse(command[4]), int.Parse(command[5]), int.Parse(command[6]), int.Parse(command[7]));
                        }
                    }
                    else if (command[0] == "Remove")
                    {
                        string teamName = command[1];
                        string PlayerName = command[2];

                        if (!teams.ContainsKey(teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            Team current = teams[teamName];
                            if (current.RemovePlayer(PlayerName) == false)
                            {
                                throw new ArgumentException($"Player {PlayerName} is not in {teamName} team.");
                            }
                            
                        }
                    }
                    else if (command[0] == "Rating")
                    {
                        string teamName = command[1];
                        if (!teams.ContainsKey(teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            Console.WriteLine($"{teamName} - {teams[teamName].Raiting()}");

                        }
                    }
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            
            }
        
        }
    }
}
