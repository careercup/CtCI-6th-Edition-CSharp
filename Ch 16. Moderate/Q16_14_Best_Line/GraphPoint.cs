using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_14_Best_Line
{
	public class GraphPoint
	{
		public double X { get; private set; }
		public double Y { get; private set; }
		public GraphPoint(double x1, double y1)
		{
			X = x1;
			Y = y1;
		}

		public override string ToString()
		{
			return "(" + X + ", " + Y + ")";
		}
	}
}
