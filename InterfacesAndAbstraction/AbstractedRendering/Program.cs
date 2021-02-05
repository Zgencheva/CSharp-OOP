using System;

using AbstractedRendering.Contracts;
using AbstractedRendering.Drawers;

namespace AbstractedRendering
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDrawer drawer = new FileDrawer("../../../game.txt");
            Game game = new Game(drawer);
            game.Start();
        }
    }
}
