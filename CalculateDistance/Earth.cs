using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateDistance
{
    public static class Earth
    {
        public static double Distance(Point from, Point to)
        {
            //
            // =ACOS(SIN(lat1)*SIN(lat2)+COS(lat1)*COS(lat2)*COS(lon2-lon1))*6371   
            // https://www.mapanet.eu/EN/resources/Script-Distance.htm
            //
            double dist = Math.Acos(Math.Sin(DegreeToRadian(from.LatitudeDegrees)) * Math.Sin(DegreeToRadian(to.LatitudeDegrees)) +
                Math.Cos(DegreeToRadian(from.LatitudeDegrees)) * Math.Cos(DegreeToRadian(to.LatitudeDegrees)) * Math.Cos(DegreeToRadian(to.LongitudeDegrees - from.LongitudeDegrees))) * 6371;
            return dist * 1000; // meters
        }

        private static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static double FitUnitsToDecimalDegrees(double units)
        {
            return units * ((double)180 / (Math.Pow((double)2, (double)31)));
        }
    }
}
