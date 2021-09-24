using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_11_Word_Distance
{
    public class LocationPair
    {
        public int Location1 { get; set; }
        public int Location2 { get; set; }
        public LocationPair(int first, int second)
        {
            SetLocations(first, second);
        }

        public void SetLocations(int first, int second)
        {
            this.Location1 = first;
            this.Location2 = second;
        }

        public void SetLocations(LocationPair loc)
        {
            SetLocations(loc.Location1, loc.Location2);
        }

        public int Distance()
        {
            return Math.Abs(Location1 - Location2);
        }

        public bool IsValid()
        {
            return Location1 >= 0 && Location2 >= 0;
        }

        public void UpdateWithMin(LocationPair loc)
        {
            if (!IsValid() || loc.Distance() < Distance())
            {
                SetLocations(loc);
            }
        }

        public override string ToString()
        {
            return "(" + Location1 + ", " + Location2 + ")";
        }
    }
}
