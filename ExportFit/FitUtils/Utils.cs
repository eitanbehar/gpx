using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitUtils
{
    public class Utils
    {
        public static double Distance(Trackpoint tp1, Trackpoint tp2)
        {
            //=ACOS(SIN(lat1)*SIN(lat2)+COS(lat1)*COS(lat2)*COS(lon2-lon1))*6371            
            double dist = Math.Acos(Math.Sin(DegreeToRadian(tp1.LatitudeDegrees)) * Math.Sin(DegreeToRadian(tp2.LatitudeDegrees)) +
                Math.Cos(DegreeToRadian(tp1.LatitudeDegrees)) * Math.Cos(DegreeToRadian(tp2.LatitudeDegrees)) * Math.Cos(DegreeToRadian(tp2.LongitudeDegrees - tp1.LongitudeDegrees))) * 6371;
            return dist;
        }

        private static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        public static double FitUnitsToDecimalDegrees(double units)
        {
            return units * ((double)180 / (Math.Pow((double)2, (double)31)));
        }

        public static void SetPoint(Trackpoint tp1, Trackpoint tp2, double Distance)
        {
            double dist = 0;
            do
            {
                tp2.LongitudeDegrees += 0.000001;
                tp2.LatitudeDegrees += 0.000001;
                dist = Utils.Distance(tp1, tp2);
            } while (dist < Distance);
        }
    }
}
