using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynastream.Fit; // downloaded from http://www.thisisant.com/resources/fit // also decoder code used from corresponding example
using System.IO;
using System.Xml.Linq;
//
namespace VirtualRoute
{
    class Program
    {
        static void Main()
        {

            string fitFile = @"c:\temp\2013-07-10-08-00-25.fit";
            string tcxFile = @"c:\temp\2013-07-10-08-00-25.tcx";

            Tcx tcx = Fit.ReadFitFileIntoTcxObject(fitFile);


           //actual distance, read from static device, elliptical track
            tcx.DistanceMeters = 4000;
            tcx.Calories = 389; // TODO - read this from FIT
            
            int numberOfTrackPoints = tcx.TrackpointList.Count();
            double distPerPoint = (double) (tcx.DistanceMeters / 1000) / numberOfTrackPoints;

            tcx.TotalTimeSeconds = (tcx.TrackpointList[numberOfTrackPoints - 1].Time - tcx.TrackpointList[0].Time).TotalSeconds;

            // set starting point
            tcx.TrackpointList[0].LatitudeDegrees = 31.245080;
            tcx.TrackpointList[0].LongitudeDegrees = 34.812100;

            for (int i = 1; i < tcx.TrackpointList.Count(); i++)
            {
                tcx.TrackpointList[i].LongitudeDegrees = tcx.TrackpointList[i - 1].LongitudeDegrees;
                tcx.TrackpointList[i].LatitudeDegrees = tcx.TrackpointList[i -1].LatitudeDegrees;
                Utils.SetPoint(tcx.TrackpointList[i - 1], tcx.TrackpointList[i], distPerPoint);
            }
            
            tcx.Save(tcxFile);

            return;

        }

    }

}
