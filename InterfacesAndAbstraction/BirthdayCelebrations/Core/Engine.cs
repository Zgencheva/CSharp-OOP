using System;
using System.Collections.Generic;
using System.Text;

using BirthdayCelebrations.Contracts;
using BirthdayCelebrations.Models;

namespace BirthdayCelebrations.Core
{
    public class Engine
    {
        public Engine()
        {

        }

        public void Run()
        {
            List<IBirthdayable> all = new List<IBirthdayable>();
            //DateTime DATE = new DateTime(2015, 02, 03);
            
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                string[] tokens = command.Split();
                if (tokens[0] == "Citizen")
                {
                    string[] date = tokens[4].Split('/');
                    DateTime thisBirthdate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                    IBirthdayable citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], thisBirthdate);
                    all.Add(citizen);
                }
                else if (tokens[0] == "Pet")
                {
                    string[] date = tokens[2].Split('/');
                    DateTime thisBirthdate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                    IBirthdayable robot = new Pet(tokens[0], thisBirthdate);
                    all.Add(robot);

                }
                else
                {
                    continue;
                }
            }

            int year = int.Parse(Console.ReadLine());

            for (int i = 0; i < all.Count; i++)
            {
                if (all[i].BirthDate.Year == year)
                {
                    //10/10/1990
                    Console.WriteLine($"{all[i].BirthDate.Day:d2}/{all[i].BirthDate.Month:d2}/{all[i].BirthDate.Year}");
                }
            }

        }
    }
}
