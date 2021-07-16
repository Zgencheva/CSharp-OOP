using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            while (true)
            {
                if (bunny.Energy == 0)
                {
                    break;
                }
                if (bunny.Dyes.All(x=> x.IsFinished() == true))
                {
                    break;
                }
                IDye currentDye = bunny.Dyes.FirstOrDefault(x => x.IsFinished() == false);
                while (true)
                {
                    if (currentDye.IsFinished())
                    {
                        break;
                    }
                    currentDye.Use();
                    bunny.Work();
                    egg.GetColored();
                    if (egg.IsDone())
                    {
                        break;
                    }
                }
                //currentDye.Use();             
                //bunny.Work();
                //egg.GetColored();
                if (egg.IsDone())
                {
                    break;
                }
            }
        }
    }
}
