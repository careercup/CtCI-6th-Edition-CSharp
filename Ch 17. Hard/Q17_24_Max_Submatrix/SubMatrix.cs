using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_24_Max_Submatrix
{
	public class SubMatrix
	{
		private int row1, row2, col1, col2, sum;
		public SubMatrix(int r1, int c1, int r2, int c2, int sm)
		{
			row1 = r1;
			col1 = c1;
			row2 = r2;
			col2 = c2;
			sum = sm;
		}

		public int GetSum()
		{
			return sum;
		}

		public override string ToString()
		{
			return "[(" + row1 + "," + col1 + ") -> (" + row2 + "," + col2 + ") = " + sum + "]";
		}
	}
}
