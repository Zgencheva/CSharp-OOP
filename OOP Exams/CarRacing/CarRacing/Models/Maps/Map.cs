using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (racerOne.IsAvailable() == false && racerTwo.IsAvailable() == false)
            {
                return "Race cannot be completed because both racers are not available!";
            }
            if (racerOne.IsAvailable() == false)
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }
            if (racerTwo.IsAvailable() == false)
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            racerOne.Race();
            racerTwo.Race();
            double racingBehaviorMultiplierR1 = 0;
            if (racerOne.RacingBehavior == "strict")
            {
                racingBehaviorMultiplierR1 = 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                racingBehaviorMultiplierR1 = 1.2;
            }
            double R1chanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplierR1;

            double racingBehaviorMultiplierR2 = 0;
            if (racerOne.RacingBehavior == "strict")
            {
                racingBehaviorMultiplierR2 = 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                racingBehaviorMultiplierR2 = 1.2;
            }
            double R2chanceOfWinning = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplierR2;

            if (R1chanceOfWinning > R2chanceOfWinning)
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerOne.Username} is the winner!";
            }
            else
            {
                return $"{racerOne.Username} has just raced against {racerTwo.Username}! {racerTwo.Username} is the winner!";
            }
        }
    }
}
