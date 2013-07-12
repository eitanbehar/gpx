using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using GPX_Analyst.Model;
using System.Collections.ObjectModel;

namespace GPX_Analyst.DataProvider
{
    public static class GPXData
    {
        public static Track Load(string GPXFilename)
        {
            Track track = new Track();

            XDocument gpxDoc = XDocument.Load(GPXFilename);

            XNamespace ns = gpxDoc.Document.Root.Name.Namespace;
            XElement root = gpxDoc.Element(ns + "gpx");

            XElement name = root.Element(ns + "trk").Element(ns + "name");

            if (name != null)
                track.Name = name.Value;
            
            XElement time = root.Element(ns + "metadata").Element(ns + "time");
            if (time != null)
                track.Time =  time.Value;
            
            track.Segments = new List<Segment>();

            foreach (XElement segmentElement in gpxDoc.Descendants(ns + "trkseg"))
            {
                Segment segment = new Segment(String.Format("Segment {0}", track.Segments.Count + 1));
                segment.Points = new List<Point>();

                foreach (XElement pointElemenent in segmentElement.Descendants(ns + "trkpt"))
                {
                    double latitude = double.Parse(pointElemenent.Attribute("lat").Value);
                    double longitude = double.Parse(pointElemenent.Attribute("lon").Value);
                    DateTime pointTime = DateTime.Parse(pointElemenent.Descendants(ns + "time").First().Value);

                    segment.Points.Add(new Point(latitude, longitude, pointTime));
                }

                track.Segments.Add(segment);

            }

            return track  ;
        }
    }
}
