using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePatternShallowAndDeepCopyExample
{
    public class Sandwich : IPrototype<Sandwich>
    {
        public string Bread { get; set; }
        public string  Meet { get; set; }
        public string  Veggie { get; set; }
        public Drink Drink { get; set; }

        public Sandwich(string bread, string meet, string veggie, Drink drink)
        {
            Bread = bread;
            Meet = meet;
            Veggie = veggie;
            Drink = drink;
        }

        public Sandwich DeepCopy()
        {
            var sandwich2 = this.MemberwiseClone() as Sandwich;
            sandwich2.Bread = new string(this.Bread);
            sandwich2.Meet = new string(this.Meet);
            sandwich2.Veggie = new string(this.Veggie);
            //syzdavame nova referenciq na drink, za da se kopira, a ne da se prehvyrlq!
            sandwich2.Drink = new Drink(this.Drink.Name);
          
            return sandwich2;
        }

        public Sandwich ShallowCopy()
        {
            return this.MemberwiseClone() as Sandwich;
        }

        public override string ToString()
        {
            return $"{Bread}, {Meet}, {Veggie}, {Drink.Name}";
        }
    }
}
