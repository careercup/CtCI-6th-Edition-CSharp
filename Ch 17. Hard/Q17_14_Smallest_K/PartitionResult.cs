using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_14_Smallest_K
{
	public class PartitionResult
	{
		public int LeftSize { get; private set; }
		public int MiddleSize { get; private set; }
		public PartitionResult(int left, int middle)
		{
			this.LeftSize = left;
			this.MiddleSize = middle;
		}
	}
}
