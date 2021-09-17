using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_13_Bisect_Squares
{
	public class Line
	{
		public Point Start { get; private set; }
		public Point End { get; private set; }
		public Line(Point start, Point end)
		{
			this.Start = start;
			this.End = end;
		}

		public override string ToString()
		{
			return "Line from " + Start.ToString() + " to " + End.ToString();
		}
	}
}
