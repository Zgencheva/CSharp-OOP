using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Height = height;
            this.Width = width;
        }
        private double Length 
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        private double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        private double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
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
            return 2 * this.length * this.width + 2 * this.length * this.height + 2*this.width * this.height;
        }

        public double Volume()
        {
            //lwh
            return this.height * this.width * this.length;
        }

        //public override string ToString()
        //{
        //    //Surface Area - 52.00
        //    //Lateral Surface Area - 40.00
        //    //Volume - 24.00

        //    return base.ToString();
        //}

    }
}
