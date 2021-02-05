using System;
using System.Collections.Generic;
using System.Text;

using AbstractedRendering.Contracts;
using AbstractedRendering.Drawers;

namespace AbstractedRendering
{
    public class Snake : IGameObject
    {
        public void Draw(IDrawer drawer)
        {
            drawer.WriteLine("Az sym zmiq");
        }
    }
}
