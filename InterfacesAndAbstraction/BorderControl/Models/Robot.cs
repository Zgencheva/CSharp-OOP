using System;
using System.Collections.Generic;
using System.Text;

using BorderControl.Contracts;

namespace BorderControl.Models
{
    public class Robot : IIdentifiable
    {
        public string ID { get; }

        public string Model { get; set; }

        public Robot(string model, string id)
        {
            this.Model = model;
            this.ID = id;
        }
    }
}
