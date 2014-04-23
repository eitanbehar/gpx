using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showers
{
    public class Showers
    {
        bool AreShowersReady()
        {
            TimeSpan ts = new TimeSpan(14, 0, 0, 0);
            if (DateTime.Now == DateTime.Now.Add(ts))
                return true;
            else
                return false;
        }
    }
}
