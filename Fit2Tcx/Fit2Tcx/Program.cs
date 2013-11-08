using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dynastream.Fit; // downloaded from http://www.thisisant.com/resources/fit // also decoder code used from corresponding example
using System.IO;
using System.Xml.Linq;
//
namespace Fit2Tcx
{
    class Program
    {
        static void Main()
        {

            string fitFile = @"D:\Batey\Downloads\2013-11-08-08-09-08-eitan.fit";
            string tcxFile = Path.Combine(Path.GetDirectoryName(fitFile), Path.GetFileNameWithoutExtension(fitFile) + ".tcx");

            Tcx tcx = Fit.ReadFitFileIntoTcxObject(fitFile);

           ////actual distance, read from device, to be calculated in the future
            tcx.DistanceMeters = 31440;
           // tcx.Calories = 389; // TODO - read this from FIT
            
            int numberOfTrackPoints = tcx.TrackpointList.Count();
           // double distPerPoint = (double) (tcx.DistanceMeters / 1000) / numberOfTrackPoints;

            tcx.TotalTimeSeconds = (tcx.TrackpointList[numberOfTrackPoints - 1].Time - tcx.TrackpointList[0].Time).TotalSeconds;


            for (int i = 0; i < tcx.TrackpointList.Count(); i++)
            {
                tcx.TrackpointList[i].LongitudeDegrees = Utils.FitUnitsToDecimalDegrees(tcx.TrackpointList[i].LongitudeDegrees);
                if (tcx.TrackpointList[i].LongitudeDegrees > 90)
                {
                    tcx.TrackpointList[i].LongitudeDegrees = tcx.TrackpointList[i-1].LongitudeDegrees;
                }

                tcx.TrackpointList[i].LatitudeDegrees = Utils.FitUnitsToDecimalDegrees(tcx.TrackpointList[i].LatitudeDegrees);
                if (tcx.TrackpointList[i].LatitudeDegrees > 90)
                {
                    tcx.TrackpointList[i].LatitudeDegrees = tcx.TrackpointList[i-1].LatitudeDegrees;
                }
            }
            
            tcx.Save(tcxFile);

            return;

        }

    }

}
