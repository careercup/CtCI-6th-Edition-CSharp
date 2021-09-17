using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_03_Intersection
{
	public class Tester
	{

		public static bool Equalish(double a, double b)
		{
			return Math.Abs(a - b) < .001;
		}

		public static bool CheckIfPointOnLineSegments(Point start, Point middle, Point end)
		{
			if (Equalish(start.X, middle.X) && Equalish(start.Y, middle.Y))
			{
				return true;
			}
			if (Equalish(middle.X, end.X) && Equalish(middle.Y, end.Y))
			{
				return true;
			}
			if (start.X == end.X)
			{ // Vertical
				if (Equalish(start.X, middle.X))
				{
					return Q16_03_Intersection.IsBetween(start, middle, end);
				}
				return false;
			}
			Line line = new Line(start, end);
			double x = middle.X;
			double y = line.Slope * x + line.Yintercept;
			if (Equalish(y, middle.Y))
			{
				return true;
			}
			return false;
		}

		public static IList<Point> GetPoints(int size)
		{
			IList<Point> points = new List<Point>();
			for (int x1 = size * -1; x1 < size; x1 += 3)
			{
				for (int y1 = size * -1 + 1; y1 < size - 1; y1 += 3)
				{
					points.Add(new Point(x1, y1));
				}
			}
			return points;
		}

		public static bool RunTest(Point start1, Point end1, Point start2, Point end2)
		{
			Point intersection = Q16_03_Intersection.Intersection(start1, end1, start2, end2);
			bool validate1 = true;
			bool validate2 = true;
			if (intersection == null)
			{
				Console.WriteLine("No intersection.");
			}
			else
			{
				validate1 = CheckIfPointOnLineSegments(start1, intersection, end1);
				validate2 = CheckIfPointOnLineSegments(start2, intersection, end2);
				if (validate1 && validate2)
				{
					Console.WriteLine("has intersection");
				}
				if (!validate1 || !validate2)
				{
					Console.WriteLine("ERROR -- " + validate1 + ", " + validate2);
				}
			}

			Console.WriteLine("  Start1: " + start1.X + ", " + start1.Y);
			Console.WriteLine("  End1: " + end1.X + ", " + end1.Y);
			Console.WriteLine("  Start2: " + start2.X + ", " + start2.Y);
			Console.WriteLine("  End2: " + end2.X + ", " + end2.Y);
			if (intersection != null)
			{
				Console.WriteLine("  Intersection: " + intersection.X + ", " + intersection.Y);
			}

			if (!validate1 || !validate2)
			{
				return false;
			}
			return true;
		}

		public static void Main(String[] args)
		{
			IList<Point> points = GetPoints(10);
			foreach (Point start1 in points)
			{
				foreach (Point end1 in points)
				{
					foreach (Point start2 in points)
					{
						foreach (Point end2 in points)
						{
							bool success = RunTest(start1, end1, start2, end2);
							if (!success)
							{
								return;
							}
						}
					}
				}
			}
		}

	}
}
