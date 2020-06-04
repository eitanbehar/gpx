using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            var home = new Point(31.286530578508973, 34.80157303623855);
            var from = new Point(32.0654096, 34.7616304); // David Intercontinental TLV
            var to = new Point(32.083944, 34.7954446); // Savidor
            var distance = Earth.Distance(from, to);
            Console.WriteLine(distance);
        }
    }
}
