using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();
            string[] tokens = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string token in tokens)
            {
                string[] tok = token.Split('=');
                string name = tok[0].Trim();
                decimal money = decimal.Parse(tok[1].Trim());
                try
                {
                    persons.Add(new Person(name, money));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            tokens = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string token in tokens)
            {
                string[] tok = token.Split('=');
                string name = tok[0].Trim();
                decimal cost = decimal.Parse(tok[1].Trim());
                try
                {
                    products.Add(new Product(name, cost));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                tokens = command.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];
                string productName = tokens[1];
                Person person = persons.Where(p => p.Name == personName).First();
                Product product = products.Where(p => p.Name == productName).First();

                person.BuyProduct(product);

                command = Console.ReadLine();
            }

            foreach (Person person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
