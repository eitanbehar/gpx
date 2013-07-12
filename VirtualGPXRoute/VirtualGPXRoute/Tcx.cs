using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VirtualGPXRoute
{
    class Tcx
    {
        public string Sport = String.Empty;
        public string Id = String.Empty;
        public DateTime StartTime ;
        public double DistanceMeters;
        public double TotalTimeSeconds;
        public int Calories;
        
        public List<Trackpoint> TrackpointList = new List<Trackpoint>();

        public void Save(String Filename)
        {
            XElement xTrack = new XElement("Track");

            foreach (Trackpoint trackPoint in TrackpointList)
            {
                xTrack.Add(trackPoint.GetTrackpoint());
            }

            XElement xTcx = new XElement("Activities",
                new XElement("Activity", new XAttribute("Sport", Sport),
                    new XElement("Id", Id),                   
                    new XElement("Lap", new XAttribute("StartTime", Trackpoint.ConvertDate(StartTime)),
                         new XElement("DistanceMeters", DistanceMeters),
                         new XElement("Calories", Calories),
                         new XElement("TotalTimeSeconds", TotalTimeSeconds),
                        xTrack)));

            xTcx.Save(Filename);

        }

    }
}
