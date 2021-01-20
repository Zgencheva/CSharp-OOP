﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animals
    {
        private int age;
        private string gender;
        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (char.IsDigit(value[0]) == true)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.name = value;
            }
        }
        public int Age 
        {
            get

            {
                return this.age;
            }

            set
            {
                
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }

                this.age = value;
            } 
             
        }
        public virtual string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                //if (value == "Male" || value == "Female")
                //{
                //    this.gender = value;
                //}
                //else
                //{
                //    throw new ArgumentException("Invalid input!");
                //}
                this.gender = value;
            }
        }

        public Animals(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public abstract string ProduceSound();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sb.Append(this.ProduceSound());
            return sb.ToString().TrimEnd();
        }
    }
}
