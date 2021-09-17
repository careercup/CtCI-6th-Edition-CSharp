using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_13_Bisect_Squares
{
	public class Square
	{
		public double Left { get; private set; }
		public double Top { get; private set; }
		public double Bottom { get; private set; }
		public double Right { get; private set; }
		public double Size { get; private set; }
		public Square(double left, double top, double size)
		{
			this.Left = left;
			this.Top = top;
			this.Bottom = top + size;
			this.Right = left + size;
			this.Size = size;
		}

		public Point Middle()
		{
			return new Point((this.Left + this.Right) / 2.0, (this.Top + this.Bottom) / 2.0);
		}

		public bool Contains(Square other)
		{
			if (this.Left <= other.Left && this.Right >= other.Right && this.Top <= other.Top && this.Bottom >= other.Bottom)
			{
				return true;
			}
			return false;
		}

		/* Return the point where the line segment connecting mid1 and
		 * mid2 intercepts the edge of square 1. That is, draw a line 
		 * from mid2 to mid1, and continue it out until the edge of
		 * the square. */
		public Point Extend(Point mid1, Point mid2, double size)
		{
			/* Find what direction the line mid2 -> mid1 goes */
			double xdir = mid1.X < mid2.X ? -1 : 1;
			double ydir = mid1.Y < mid2.Y ? -1 : 1;

			/* If mid1 and mid2 have the same x value, then the slope
			 * calculation will throw a divide by 0 exception. So, we
			 * compute this specially. */
			if (mid1.X == mid2.X)
			{
				return new Point(mid1.X, mid1.Y + ydir * size / 2.0);
			}
			double slope = (mid1.Y - mid2.Y) / (mid1.X - mid2.X);
			double x1 = 0;
			double y1 = 0;

			/* Calculate slope using the equation (y1 - y2) / (x1 - x2).
			 * Note: if the slope is �steep� (>1) then the end of the
			 * line segment will hit size / 2 units away from the middle
			 * on the y axis. If the slope is �shallow� (<1) the end of
			 * the line segment will hit size / 2 units away from the
			 * middle on the x axis. */
			if (Math.Abs(slope) == 1)
			{
				x1 = mid1.X + xdir * size / 2.0;
				y1 = mid1.Y + ydir * size / 2.0;
			}
			else if (Math.Abs(slope) < 1)
			{
				x1 = mid1.X + xdir * size / 2.0;
				y1 = slope * (x1 - mid1.X) + mid1.Y;
			}
			else
			{
				y1 = mid1.Y + ydir * size / 2.0;
				x1 = (y1 - mid1.Y) / slope + mid1.X;
			}
			return new Point(x1, y1);
		}

		public Line Cut(Square other)
		{
			/* Calculate where a line between each middle would collide with the edges of the squares */
			Point p1 = Extend(this.Middle(), other.Middle(), this.Size);
			Point p2 = Extend(this.Middle(), other.Middle(), -1 * this.Size);
			Point p3 = Extend(other.Middle(), this.Middle(), other.Size);
			Point p4 = Extend(other.Middle(), this.Middle(), -1 * other.Size);

			/* Of above points, find start and end of lines. Start is farthest left (with top most as a tie breaker)
			 * and end is farthest right (with bottom most as a tie breaker */
			Point start = p1;
			Point end = p1;
			Point[] points = { p2, p3, p4 };
			for (int i = 0; i < points.Length; i++)
			{
				if (points[i].X < start.X || (points[i].X == start.X && points[i].Y < start.Y))
				{
					start = points[i];
				}
				else if (points[i].X > end.X || (points[i].X == end.X && points[i].Y > end.Y))
				{
					end = points[i];
				}
			}

			return new Line(start, end);
		}

		public override string ToString()
		{
			return "(" + Left + ", " + Top + ")|(" + Right + "," + Bottom + ")";
		}
	}
}
