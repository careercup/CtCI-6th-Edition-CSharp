using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_15_Master_Mind
{
	public class Result
	{
		public int Hits { get; set; }
		public int PseudoHits { get; set; }

		public Result(int h, int p)
		{
			Hits = h;
			PseudoHits = p;
		}

		public override string ToString()
		{
			return "Result [hits=" + Hits + ", pseudoHits=" + PseudoHits + "]";
		}
	}
}
