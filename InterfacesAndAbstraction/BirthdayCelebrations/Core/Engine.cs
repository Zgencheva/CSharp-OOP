using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();
            //DateTime DATE = new DateTime(2015, 02, 03);
            int n = int.Parse(Console.ReadLine());
            int totalAmount = 0;
            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();
                string[] tokens = command.Split();
                if (tokens.Length == 4)
                {
                    string[] date = tokens[3].Split('/');
                    DateTime thisBirthdate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));
                    Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], thisBirthdate);
                    citizens.Add(citizen);
                }
                else if (tokens.Length == 3)
                {
                   
                    Rebel rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    rebels.Add(rebel);

                }
               
            }
            
            while (true)
            {
                string buyer = Console.ReadLine();
                if (buyer == "End")
                {
                    break;
                }
                if (citizens.Any(x=> x.Name == buyer))
                {
                    Citizen current = citizens.Where(x => x.Name == buyer).FirstOrDefault();
                    current.BuyFood();
                    totalAmount += 10;
                }
                else if (rebels.Any(x=> x.Name == buyer))
                {
                    Rebel current = rebels.Where(x => x.Name == buyer).FirstOrDefault();
                    current.BuyFood();
                    totalAmount += 5;
                }       
                
            }

            Console.WriteLine(totalAmount);

        }
    }
}
