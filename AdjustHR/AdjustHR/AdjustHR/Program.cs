using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AdjustHR
{
    class Program
    {
        static void Main(string[] args)
        {
            string gpxFile = @"D:\Batey\Downloads\no name.gpx";
            XElement xData = XElement.Load(gpxFile);
            //XNamespace ns = xData.Name.Namespace;
            XNamespace ns = XNamespace.Get("http://www.garmin.com/xmlschemas/TrackPointExtension/v1");

      // <trkpt lat="31.264751041308045" lon="34.81619233265519">
      //  <ele>322.4</ele>
      //  <time>2013-10-09T18:07:30Z</time>
      //  <extensions>
      //    <gpxtpx:TrackPointExtension>
      //      <gpxtpx:hr>193</gpxtpx:hr>
      //    </gpxtpx:TrackPointExtension>
      //  </extensions>
      //</trkpt>

            var hrElements = from h in xData.Descendants(ns + "hr")
                        select h;

            int Max = 220;
            int Min = 80;
            int newMax = 140;
            int newMin = 80;

            foreach (XElement hrElement in hrElements)
            {
                int hrValue = int.Parse(hrElement.Value.ToString());
                hrValue = (int) ((hrValue - Min) * ((double)(newMax - newMin) / (Max - Min))) + newMin;
                hrElement.Value = hrValue.ToString();
            }

            xData.Save(gpxFile);


        }
    }
}
