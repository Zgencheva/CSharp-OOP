using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using AbstractedRendering.Contracts;

namespace AbstractedRendering.Drawers
{
    public class HtmlDrawer : IDrawer
    {
        private string path;
        private StringBuilder result;
        public HtmlDrawer(string path)
        {
            this.path = path;
            this.result = new StringBuilder();
        }
        public void Write(string input)
        {
            using (StreamWriter writer = new StreamWriter(path + ".html", false))
            {
                //html code
                writer.Write(input);
            }
        }

        public void WriteLine(string input)
        {
            using (StreamWriter writer = new StreamWriter(path + ".html", false))
            {
                //html code
                writer.WriteLine(input);
            }
        }
    }
}
