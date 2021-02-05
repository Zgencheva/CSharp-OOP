using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractedRendering.Contracts
{
    interface IGameObject
    {
        void Draw(IDrawer drawer);
    }
}
