using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private const string EXCEPTION_MSG = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Height = height;
            this.Width = width;
        }
        public double Length 
        {
            get
            {
                return this.length;
            }
            private set
            {
                ValidateSides(value, "Length");

                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                ValidateSides(value, "Width");

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                ValidateSides(value, "Height");

                this.height = value;
            }
        }

        private void ValidateSides(double side, string s)
        {
            if (side <= 0)
            {
                throw new ArgumentException(string.Format(EXCEPTION_MSG, s));
            }
        }
        public double LateralSurfaceArea()
        {
            //Lateral Surface Area = 2lh + 2wh
            return 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);
        }

        public double SurfaceArea()
        {
            //Surface Area = 2lw + 2lh + 2wh
            return 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2*this.Width * this.Height;
        }

        public double Volume()
        {
            //lwh
            return this.Height * this.Width * this.Length;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Surface Area - {this.SurfaceArea():f2}");
           sb.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}");
            sb.AppendLine($"Volume - {this.Volume():f2}");

            return sb.ToString().TrimEnd();
        }

    }
}
