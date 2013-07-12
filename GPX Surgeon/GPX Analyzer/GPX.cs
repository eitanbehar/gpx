using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;

namespace GPX_Analyzer
{
    public class GPX
    {
        public string Filename { get; private set; }
        public string Name { get; private set; }
        public string Time { get; private set; }
        public List<TrackPoint> TrackPoints = new List<TrackPoint>();

        public GPX(string Filename)
        {
            XDocument gpxDoc = XDocument.Load(Filename);

            XNamespace ns = gpxDoc.Document.Root.Name.Namespace;
            XElement root = gpxDoc.Element(ns + "gpx");
            XElement time = root.Element(ns + "metadata").Element(ns + "time");
            if (time != null)
                this.Time = time.Value;

            XElement name = root.Element(ns + "trk").Element(ns + "name");
            if (name != null)
                this.Name = name.Value;

            foreach (XElement trackPoint in gpxDoc.Descendants(ns + "trkpt"))
            {
                TrackPoints.Add(new TrackPoint(trackPoint));
            }
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public double Distance()
        {
            double totalDist = 0;

            for (int i = 0; i < TrackPoints.Count - 1; i++)
            {
                TrackPoint tp1 = TrackPoints[i];
                TrackPoint tp2 = TrackPoints[i + 1];
                double dist = Distance(tp1, tp2);
                totalDist += dist;
            }

            return totalDist;
        }

        public double Distance(TrackPoint tp1, TrackPoint tp2)
        {
            //=ACOS(SIN(lat1)*SIN(lat2)+COS(lat1)*COS(lat2)*COS(lon2-lon1))*6371            
            double dist = Math.Acos(Math.Sin(DegreeToRadian(tp1.Lat)) * Math.Sin(DegreeToRadian(tp2.Lat)) +
                Math.Cos(DegreeToRadian(tp1.Lat)) * Math.Cos(DegreeToRadian(tp2.Lat)) * Math.Cos(DegreeToRadian(tp2.Lon - tp1.Lon))) * 6371;
            return dist;
        }

        public double Speed()
        {
            return Distance() / DeltaTime().TotalHours;
        }

        public GPXAnalysisInfo Analyze(double MinSpeed)
        {
            double totalDist = 0;
            TimeSpan totalTime = new TimeSpan();
            for (int i = 0; i < TrackPoints.Count - 1; i++)
            {
                TrackPoint tp1 = TrackPoints[i];
                TrackPoint tp2 = TrackPoints[i + 1];
                double dist = Distance(tp1, tp2);
                TimeSpan timeSpan = DeltaTime(tp1, tp2);

                double speed = Distance(tp1, tp2) / DeltaTime(tp1, tp2).TotalHours;

                if (speed >= MinSpeed)
                {
                    totalDist += dist;
                    totalTime += timeSpan;
                }
            }

            return new GPXAnalysisInfo(totalDist, totalDist / totalTime.TotalHours);
        }

        public double Speed(TrackPoint tp1, TrackPoint tp2)
        {
            return Distance(tp1, tp2) / DeltaTime(tp1, tp2).TotalHours;
        }

        public TimeSpan DeltaTime()
        {
            TimeSpan timeSpan = TrackPoints[TrackPoints.Count - 1].Time.Subtract(TrackPoints[0].Time);
            return timeSpan;
        }

        public TimeSpan DeltaTime(TrackPoint tp1, TrackPoint tp2)
        {
            TimeSpan timeSpan = tp2.Time.Subtract(tp1.Time);
            return timeSpan;
        }

    }
}
