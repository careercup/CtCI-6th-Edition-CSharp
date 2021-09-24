using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_15_Longest_Word
{
    public class LengthComparator : IComparer<string>
    {
        public int Compare(string o1, string o2)
        {
            if (o1.Length < o2.Length) return 1;
            if (o1.Length > o2.Length) return -1;
            return 0;
        }
    }
}
