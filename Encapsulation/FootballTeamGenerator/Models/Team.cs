using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private const string NameExpMsg = "A name should not be empty.";

        private string name;
        private readonly List<Player> players;

        private Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name)
            : this()
        {
            this.Name = name;
            
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(NameExpMsg);
                }

                this.name = value;
            }
        }

        //public IReadOnlyCollection<Player> Players
        //{
        //    get
        //    {
        //        return (IReadOnlyCollection<Player>)this.players;
        //    }


        //}

        public void AddPlayer(string player_name, int endurance,int sprint, int dribbel, int passing, int shooting)
        {
            Player player = new Player(player_name, sprint, shooting, endurance, dribbel, passing);
            players.Add(player);
        }

        public bool RemovePlayer(string player_name)
        {
            Player playerToRemove = players.Where(t => t.Name == player_name).FirstOrDefault();
           return players.Remove(playerToRemove);
        }

        public int Raiting()
        {
            int result = 0;
            if (players.Count != 0)
            {
                int playersCount = players.Count();

                foreach (Player player in players)
                {
                    result += player.SkillLevel;
                }
                result = result / playersCount;
               
            }
            return result;
            
        }
    }
}
