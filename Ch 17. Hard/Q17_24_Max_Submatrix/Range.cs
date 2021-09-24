using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_24_Max_Submatrix
{
    public class Range
    {
        public int Start { get; private set; }
        public int End { get; private set; }
        public int Sum { get; private set; }
        public Range(int start, int end, int sum)
        {
            this.Start = start;
            this.End = end;
            this.Sum = sum;
        }
    }
}
