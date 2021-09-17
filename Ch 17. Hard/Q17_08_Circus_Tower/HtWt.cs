using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_08_Circus_Tower
{
    public class HtWt : IComparable<HtWt>
    {
        private int height;
        private int weight;
        public HtWt(int h, int w) { height = h; weight = w; }

        public int CompareTo(HtWt second)
        {
            if (this.height != second.height)
            {
                return (this.height).CompareTo(second.height);
            }
            else
            {
                return (this.weight).CompareTo(second.weight);
            }
        }

        public override string ToString()
        {
            return "(" + height + ", " + weight + ")";
        }

        /* Returns true if "this" should be lined up before "other". Note 
         * that it's possible that this.isBefore(other) and 
         * other.isBefore(this) are both false. This is different from the 
         * compareTo method, where if a < b then b > a. */
        public bool isBefore(HtWt other)
        {
            if (height < other.height && weight < other.weight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
