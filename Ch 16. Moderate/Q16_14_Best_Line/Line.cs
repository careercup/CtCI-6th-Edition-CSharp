using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_14_Best_Line
{
	public class Line
	{
		public static double epsilon = 0.0001;
		public double Slope { get; private set; }
		public double Intercept { get; private set; }

		private readonly bool infinite_slope = false;

		public Line(GraphPoint p, GraphPoint q)
		{
			if (Math.Abs(p.X - q.X) > epsilon)
			{ // if x's are different
				Slope = (p.Y - q.Y) / (p.X - q.X); // compute slope
				Intercept = p.Y - Slope * p.X; // y intercept from y=mx+b
			}
			else
			{
				infinite_slope = true;
				Intercept = p.X; // x-intercept, since slope is infinite
			}
		}

		public bool IsEquivalent(double a, double b)
		{
			return (Math.Abs(a - b) < epsilon);
		}

		public void Print()
		{
			Console.WriteLine("y = " + Slope + "x + " + Intercept);
		}

		public static double FloorToNearestEpsilon(double d)
		{
			int r = (int)(d / epsilon);
			return ((double)r) * epsilon;
		}

		public bool IsEquivalent(Object o)
		{
			Line l = (Line)o;
			if (IsEquivalent(l.Slope, Slope) && IsEquivalent(l.Intercept, Intercept) && (infinite_slope == l.infinite_slope))
			{
				return true;
			}
			return false;
		}
	}
}
