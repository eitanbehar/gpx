using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateDistance
{
    public class Point
    {
        public double LatitudeDegrees { get; set; }
        public double LongitudeDegrees { get; set; }

        public Point(double latitude, double longitude)
        {
            this.LatitudeDegrees = latitude;
            this.LongitudeDegrees = longitude;
        }
    }
}
