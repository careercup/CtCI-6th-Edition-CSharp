using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_24_Pairs_With_Sum
{
	public class Pair
	{
		public int first { get; private set; }
		public int second { get; private set; }

		public Pair(int first, int second)
		{
			this.first = first;
			this.second = second;
		}

		public override string ToString()
		{
			return "(" + first + ", " + second + ")";
		}
	}
}
