using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPX_Analyst.Model
{
    public class Point
    {
        public double Latitute { get; private set; }
        public double Longitude { get; private set; }
        public DateTime Time { get; private set; }

        public Point(double latitude, double longitude, DateTime time)
        {
            Latitute = latitude;
            Longitude = longitude;
            Time = time;
        }
    }
}
