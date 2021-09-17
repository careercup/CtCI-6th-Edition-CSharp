using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_03_Intersection
{
	public class Line
	{
		public double Slope { get; private set; }
		public double Yintercept { get; private set; }
		
		public Point Start { get; private set; }
		public Point End { get; private set; }

		public Line(Point start, Point end)
		{
			this.Start = start;
			this.End = end;
			if (start.X == end.X)
			{
				Slope = double.PositiveInfinity;
				Yintercept = double.PositiveInfinity;
			}
			else
			{
				Slope = (end.Y - start.Y) / (end.X - start.X);
				Yintercept = end.Y - Slope * end.X;
			}
		}

		public bool isVertical()
		{
			return Slope == double.PositiveInfinity;
		}

		public override string ToString()
		{
			return "Line [slope=" + Slope + ", yintercept=" + Yintercept + ", start=" + Start + ", end=" + End + "]";
		}

		public double getYFromX(double x)
		{
			if (isVertical())
			{
				return double.PositiveInfinity;
			}
			return Slope * x + Yintercept;
		}
	}
}
