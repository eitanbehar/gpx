using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FitUtils
{
    public class Trackpoint
    {

        public static string ConvertDate(DateTime FitDate)
        {
            return FitDate.ToString("yyyy-MM-ddTHH:mm:ssZ");                                
        }

        public DateTime Time;

        public double LatitudeDegrees ;
        public double LongitudeDegrees ;
        public double AltitudeMeters;
        public int HeartRateBpm;

        public XElement GetTrackpoint()
        {
            XElement xTp = new XElement(
                    "Trackpoint",
                        new XElement("Time", ConvertDate(Time)),
                        new XElement("Position",
                            new XElement("LatitudeDegrees", LatitudeDegrees),
                            new XElement("LongitudeDegrees", LongitudeDegrees)
                            ),
                        new XElement("AltitudeMeters", AltitudeMeters),
                        new XElement("Distance", Distance),
                        new XElement("Speed", Speed),
                        new XElement("Cadence", Cadence),
                        new XElement("HeartRateBpm", 
                            new XElement("Value", HeartRateBpm))
                );

            return xTp;
        }


        public double Distance { get; set; }

        public double Power { get; set; }

        public double Grade { get; set; }

        public double Speed { get; set; }

        public double Resistance { get; set; }

        public double Cadence { get; set; }
    }

   
}
