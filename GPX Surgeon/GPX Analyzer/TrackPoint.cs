using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Data;

namespace GPX_Analyzer
{
    public class TrackPoint
    {
        public double Lat { get; private set; }
        public double Lon { get; private set; }
        public DateTime Time { get; private set; }

        public TrackPoint(XElement trkpt)
        {
            Lat = double.Parse(trkpt.Attribute("lat").Value);
            Lon = double.Parse(trkpt.Attribute("lon").Value);
            XNamespace ns = trkpt.Document.Root.Name.Namespace;
            Time = DateTime.Parse(trkpt.Descendants(ns + "time").First().Value);
        }
        
        internal static DataTable GetDatatable()
        {
            DataTable dt = new DataTable("Data");
            dt.Columns.Add("Lat");
            dt.Columns.Add("Lon");
            dt.Columns.Add("Time");
            return dt;
        }

        internal DataRow GetDataRow(DataTable dt)
        {
            DataRow dr = dt.NewRow();
            dr["Lat"] = this.Lat;
            dr["Lon"] = this.Lon;
            dr["Time"] = this.Time.ToLocalTime();
            return dr;
        }
        
    }
}
