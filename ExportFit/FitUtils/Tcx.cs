using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FitUtils
{
    public class Tcx
    {
        public string Sport = String.Empty;
        public string Id = String.Empty;
        public DateTime StartTime ;
        public double DistanceMeters = 0;
        public double TotalTimeSeconds = 0;
        public int Calories = 0;
        
        public List<Trackpoint> TrackpointList = new List<Trackpoint>();
        public byte? MaxHeartRate;
        public byte? AvgHeartRate;

        public void Save(String Filename)
        {
            XElement xTrack = new XElement("Track");

            foreach (Trackpoint trackPoint in TrackpointList)
            {
                xTrack.Add(trackPoint.GetTrackpoint());
            }

            XNamespace ns = "HeartRateInBeatsPerMinute_t";

            XElement xTcx = new XElement("Activities",
                new XElement("Activity", new XAttribute("Sport", Sport),
                    new XElement("Id", Id),                   
                    new XElement("Lap", new XAttribute("StartTime", Trackpoint.ConvertDate(StartTime)),
                         new XElement("DistanceMeters", DistanceMeters),
                         new XElement("Calories", Calories),
                         new XElement(ns + "AverageHeartRateBpm", 
                             new XElement("Value", AvgHeartRate)),
                         new XElement(ns + "MaximumHeartRateBpm",
                             new XElement("Value", MaxHeartRate)),
                         new XElement("TotalTimeSeconds", TotalTimeSeconds),
                        xTrack)));

            xTcx.Save(Filename);

        }


        public void AdjustPoints()
        {
            int numberOfTrackPoints = TrackpointList.Count();
            
            TotalTimeSeconds = (TrackpointList[numberOfTrackPoints - 1].Time - TrackpointList[0].Time).TotalSeconds;


            for (int i = 0; i < TrackpointList.Count(); i++)
            {
                TrackpointList[i].LongitudeDegrees = Utils.FitUnitsToDecimalDegrees(TrackpointList[i].LongitudeDegrees);
                if (TrackpointList[i].LongitudeDegrees > 90 && i > 0)
                {
                    TrackpointList[i].LongitudeDegrees = TrackpointList[i - 1].LongitudeDegrees;
                }

                TrackpointList[i].LatitudeDegrees = Utils.FitUnitsToDecimalDegrees(TrackpointList[i].LatitudeDegrees);
                if (TrackpointList[i].LatitudeDegrees > 90 && i > 0)
                {
                    TrackpointList[i].LatitudeDegrees = TrackpointList[i - 1].LatitudeDegrees;
                }
            }
        }

        public void CreateVirtualRoute(double InitialLatitude, double InitialLongitude)
        {
            int numberOfTrackPoints = TrackpointList.Count();
            
            // set starting point
            TrackpointList[0].LatitudeDegrees = InitialLatitude;
            TrackpointList[0].LongitudeDegrees = InitialLongitude;

            double distPerPoint = (double)(DistanceMeters / 1000) / numberOfTrackPoints;

            for (int i = 1; i < TrackpointList.Count(); i++)
            {
                TrackpointList[i].LongitudeDegrees = TrackpointList[i - 1].LongitudeDegrees;
                TrackpointList[i].LatitudeDegrees = TrackpointList[i - 1].LatitudeDegrees;
                Utils.SetPoint(TrackpointList[i - 1], TrackpointList[i], distPerPoint);
            }
        }

    }
}
