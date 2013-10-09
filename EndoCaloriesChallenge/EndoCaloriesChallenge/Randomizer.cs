using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EndoCaloriesChallenge
{
    public class Randomizer
    {
        Random r; 
        
        public Randomizer()
        {
            long timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).Ticks);

            int seed = Convert.ToInt32(Convert.ToString(timestamp).Substring(11));

            r = new Random(seed);
        }

        public int GetRandomTicket(int intMin, int intMax)
        {
            return r.Next(intMin, intMax);
        }

    }
}
