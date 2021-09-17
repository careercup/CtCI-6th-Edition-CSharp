using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_16_Sub_Sort
{
    public class Range
    {
        public int Start { get; private set; }
        public int End { get; private set; }
        public Range(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public override string ToString()
        {
            return "Range [start=" + Start + ", end=" + End + "]";
        }

        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            result = prime * result + End;
            result = prime * result + Start;
            return result;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            Range other = (Range)obj;
            if (End != other.End)
                return false;
            if (Start != other.Start)
                return false;
            return true;
        }
    }
}
