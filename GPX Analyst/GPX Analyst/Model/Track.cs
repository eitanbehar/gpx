using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace GPX_Analyst.Model
{
    public class Track
    {
        public string Name { get; set; }
        public string Source { get; set; }
        public string Type { get; set; }
        public string Time { get; set; }

        public List<Segment> Segments { get; set; }

    }
}
