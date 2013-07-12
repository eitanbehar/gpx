using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPX_Analyzer
{
    public class GPXAnalysisInfo
    {
        public double Speed = 0;
        public double Distance = 0;

        public GPXAnalysisInfo(double Distance, double Speed)
        {
            this.Speed = Speed;
            this.Distance = Distance;
        }

    }
}
