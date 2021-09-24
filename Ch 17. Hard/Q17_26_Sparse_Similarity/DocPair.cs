using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_26_Sparse_Similarity
{
	public class DocPair
	{
		public int Doc1 { get; private set; }
		public int Doc2 { get; private set; }

		public DocPair(int d1, int d2)
		{
			Doc1 = d1;
			Doc2 = d2;
		}

		public override bool Equals(object o)
		{
			if (o is DocPair) {
				DocPair p = (DocPair)o;
				return p.Doc1 == Doc1 && p.Doc2 == Doc2;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (Doc1 * 31) ^ Doc2;
		}
	}

}
