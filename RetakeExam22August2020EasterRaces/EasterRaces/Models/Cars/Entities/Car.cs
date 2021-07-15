using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int minHorsePower;
        private int maxHorsepower;
        //private CarRepository carRepository;

        protected Car(string model, int horsePower, double cubicCentimeters)
        {
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
         
            
        }
        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsepower, int maxHorsepower)
            :this(model, horsePower, cubicCentimeters)
        {
           
            this.minHorsePower = minHorsepower;
            this.maxHorsepower = maxHorsepower;
        }

        public string Model
        {
            get 
            {
                return this.model;
            }
            private set 
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length <4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value));
                }
                this.model = value;
            }

        }
            
        public int HorsePower
        {
            get 
            {
                return this.horsePower;
            }
            private set
            {
                //TODO can they be = eigter
                if (value < minHorsePower || value > maxHorsepower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }
                this.horsePower = value;
            
            }
        }

        public virtual double CubicCentimeters
        {
            get
            {
                return this.cubicCentimeters;
            }
            private set
            {
                this.cubicCentimeters = value;

            }
        }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
