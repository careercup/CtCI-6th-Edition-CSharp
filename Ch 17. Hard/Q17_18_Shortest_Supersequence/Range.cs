using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_18_Shortest_Supersequence
{
	public class Range
	{
		private int start;
		private int end;
		public Range(int s, int e)
		{
			start = s;
			end = e;
		}

		public int Length()
		{
			return end - start + 1;
		}

		public override int GetHashCode()
		{
			int prime = 31;
			int result = 1;
			result = prime * result + end;
			result = prime * result + start;
			return result;
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
				return true;
			if (obj == null)
				return false;
			if (this.GetType() != obj.GetType())
				return false;
			Range other = (Range)obj;
			if (end != other.end)
				return false;
			if (start != other.start)
				return false;
			return true;
		}

		public override string ToString()
		{
			return "Range [start=" + start + ", end=" + end + "]";
		}

		public bool ShorterThan(Range other)
		{
			return Length() < other.Length();
		}

		public int GetStart()
		{
			return start;
		}

		public int GetEnd()
		{
			return end;
		}
	}

}
