using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_13_Bisect_Squares
{
	public class Point
	{
		public double X { get; private set; }
		public double Y { get; private set; }
		public Point(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		public bool Equals(Point p)
		{
			return (p.X == X && p.Y == Y);
		}

		public override string ToString()
		{
			return "(" + X + ", " + Y + ")";
		}
	}
}
