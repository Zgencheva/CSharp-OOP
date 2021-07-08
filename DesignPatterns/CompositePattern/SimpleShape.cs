using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public class SimpleShape : IDrawable
    {
        public string Name { get; set; }

        public SimpleShape(string name)
        {
            this.Name = name;
        }

        public void AddChild(IDrawable child)
        {
            throw new ArgumentException("Simple shapes cannot have children");
        }

        public void Draw(int level)
        {
            Console.Write(new string(' ', level));
            Console.WriteLine(Name);
        }
    }
}
