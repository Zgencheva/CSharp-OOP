using System;
using System.Collections.Generic;
using System.Text;

using AbstractedRendering.Contracts;
using AbstractedRendering.Drawers;

namespace AbstractedRendering
{
    public class Food : IGameObject
    {
        public int IsEaten { get; set; }

        public void Draw(IDrawer drawer)
        {
            drawer.WriteLine("az sym hrana");
        }
    }
}
