using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private const string NameExpMsg = "A name should not be empty.";
        private const string StatExpMasg = "{0} should be between 0 and 100.";

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int sprint, int shooting, int endurance, int dribble, int passing)
        {
            this.Name = name;
            this.Sprint = sprint;
            this.Shooting = shooting;
            this.Endurance = endurance;
            this.Dribble = dribble;
            this.Passing = passing;
        }
        public string Name 
        { get
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
        

        public int Sprint
        { get
            {
                return this.sprint;
            }
            private set
            {
                if (0<= value && value <= 100 )
                {
                    this.sprint = value;
                }
                else
                {
                throw new ArgumentException(string.Format(StatExpMasg, "Sprint"));
                }
                
            }
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            private set
            {
                if (0 <= value && value <= 100)
                {
                    this.endurance = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(StatExpMasg, "Endurance"));
                }

            }
        }
        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                if (0 <= value && value <= 100)
                {
                    this.dribble = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(StatExpMasg, "Dribble"));
                }

            }
        }

        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                if (0 <= value && value <= 100)
                {
                    this.passing = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(StatExpMasg, "Passing"));
                }

            }
        }

        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                if (0 <= value && value <= 100)
                {
                    this.shooting = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(StatExpMasg, "Shooting"));
                }

            }
        }

        public int SkillLevel => this.CalculateSkillLevel();
        private int CalculateSkillLevel()
        {
            return (int)Math.Round((this.Passing + this.Sprint + this.Shooting + this.Endurance + this.Dribble) / 5.0);

        }
    }
}
