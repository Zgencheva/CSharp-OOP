using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public class ComplexShape : IDrawable
    {
        private List<IDrawable> shapes = new List<IDrawable>();

        public string Name { get; set; }

        public ComplexShape(string name)
        {
            this.Name = name;
        }

        public void AddChild(IDrawable child)
        {
            shapes.Add(child);
        }

        public void Draw(int level)
        {
            Console.Write(new string(' ', level));
            Console.WriteLine(Name);
            foreach (var item in shapes)
            {
                item.Draw(level + 3);
            }
        }

        
    }
}
