using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPX_Analyst.Model
{
    public class Segment
    {
        public List<Point> Points { get; set; }

        public string Name { get; set; }

        public Segment(string Name)
        {
            this.Name = Name;
        }
    }
}
