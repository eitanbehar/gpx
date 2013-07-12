using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
namespace AddHRtoGPX
{
    class Program
    {
        static void Main(string[] args)
        {
            string gpxFile = @"D:\Batey\Downloads\2013-06-29-07-09-09.gpx";
            string cvsFile = @"D:\Batey\Downloads\2013-06-29-07-09-09.csv";
            XElement xData = XElement.Load(gpxFile);
            XNamespace ns = xData.Name.Namespace;
            foreach (string line in File.ReadAllLines(cvsFile))
            {
                if (!line.StartsWith("data,6,2013-06-29"))
                    continue;
                string[] data = line.Split(new char[] {
					   ','});
                string date = data[2].Replace(" ", "T") + "Z";
                string heartRate = data[10];
                var track = from t in xData.Descendants(ns + "trkpt")
                            where String.Compare(t.Element(ns + "time").Value.ToString(), date, true) == 0
                            select t;
                foreach (XElement target in track)
                {
                    target.Add(GetHRElement(heartRate));
                }
            } xData.Save(@"D:\Batey\Downloads\temptrack_with_hr.gpx");
        }
        private static XElement GetHRElement(string heartRate)
        {
            XNamespace ns = XNamespace.Get("http://www.garmin.com/xmlschemas/TrackPointExtension/v1");
            XElement e = new XElement("extensions");
            e.Add(new XElement(ns + "TrackPointExtension", new XElement(ns + "hr", heartRate)));
            return e;
        }
    }
}