using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_23_Max_Black_Square
{
	public class SquareCell
	{
		public int ZerosRight { get; private set; } = 0;
		public int ZerosBelow { get; private set; } = 0;
		public SquareCell(int right, int below)
		{
			ZerosRight = right;
			ZerosBelow = below;
		}

		public void SetZerosRight(int right)
		{
			ZerosRight = right;
		}

		public void SetZerosBelow(int below)
		{
			ZerosBelow = below;
		}
	}
}
