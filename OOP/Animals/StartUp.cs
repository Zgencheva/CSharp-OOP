using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Tomcat tom = new Tomcat("Tom", 13, "female");
            //Tomcat tom2 = new Tomcat("Tom", 13);
            //Console.WriteLine(tom.Gender);

            //Console.WriteLine(tom.ProduceSound());

            List<Animals> animals = new List<Animals>();


            while (true)
            {
                string type = Console.ReadLine();
                if (type == "Beast!")
                {
                    break;

                }
                try
                {
                    string[] tokens = Console.ReadLine().Split();
                    string animalName = tokens[0];
                    int animalAge = int.Parse(tokens[1]);
                   
                    string animalGender = tokens[2];
                    
                    if (type == "Cat")
                    {
                        Cat currentCat = new Cat(animalName, animalAge, animalGender);
                        animals.Add(currentCat);
                    }
                    else if (type == "Dog")
                    {
                        Dog currentDog = new Dog(animalName, animalAge, animalGender);
                        animals.Add(currentDog);
                    }
                    else if (type == "Frog")
                    {
                        Frog currentFrog = new Frog(animalName, animalAge, animalGender);
                        animals.Add(currentFrog);
                    }
                    else if (type == "Kitten")
                    {
                        Kitten current = new Kitten(animalName, animalAge, animalGender);
                        animals.Add(current);
                    }
                    else if (type == "Tomcat")
                    {
                        Tomcat current = new Tomcat(animalName, animalAge, animalGender);
                        animals.Add(current);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }




            foreach (Animals item in animals)
            {
                Console.WriteLine(item);
            }
        }
    }
}
