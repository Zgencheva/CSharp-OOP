using System;
using System.Collections.Generic;
using System.Text;

using AbstractedRendering.Contracts;
using AbstractedRendering.Drawers;

namespace AbstractedRendering
{
    public class Obstacle : IGameObject
    {
        public void Draw(IDrawer drawer)
        {
            drawer.WriteLine("Obstacle na pytq");
        }
    }
}
