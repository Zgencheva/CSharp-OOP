using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory
{
    public class AnimalFactory
    {
        public static IAnimal CreateAnimal(string name)
        {
            if (name == "peshoJivotnoto")
            {
                return new PeshoJivotnoto();
            }
            else
            {
                return new Lion();
            }
        }
    }
}
