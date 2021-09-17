using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_14_Best_Line
{
    public class Q16_14_Best_Line : Question
    {
		/* Find line that goes through most number of points. */
		public static Line FindBestLine(GraphPoint[] points)
		{
			Dictionary<double, IList<Line>> linesBySlope = GetListOfLines(points);
			return GetBestLine(linesBySlope);
		}

		/* Add each pair of points as a line to the list. */
		public static Dictionary<double, IList<Line>> GetListOfLines(GraphPoint[] points)
		{
			Dictionary<double, IList<Line>> linesBySlope = new Dictionary<double, IList<Line>>();
			for (int i = 0; i < points.Length; i++)
			{
				for (int j = i + 1; j < points.Length; j++)
				{
					Line line = new Line(points[i], points[j]);
					double key = Line.FloorToNearestEpsilon(line.Slope);
					if (!linesBySlope.ContainsKey(key)) linesBySlope[key] = new List<Line>();
					linesBySlope[key].Add(line);
				}
			}
			return linesBySlope;
		}

		/* Return the line with the most equivalent other lines. */
		public static Line GetBestLine(Dictionary<double, IList<Line>> linesBySlope)
		{
			Line bestLine = null;
			int bestCount = 0;

			var slopes = linesBySlope.Keys;

			foreach (double slope in slopes)
			{
				IList<Line> lines = linesBySlope[slope];
				foreach (Line line in lines)
				{
					/* count lines that are equivalent to current line */
					int count = CountEquivalentLines(linesBySlope, line);

					/* if better than current line, replace it */
					if (count > bestCount)
					{
						bestLine = line;
						bestCount = count;
						bestLine.Print();
						Console.WriteLine(bestCount);
					}
				}
			}
			return bestLine;
		}

		/* Check hashmap for lines that are equivalent. Note that we need to check one epsilon above and below the actual slope
		 * since we're defining two lines as equivalent if they're within an epsilon of each other.
		 */
		public static int CountEquivalentLines(Dictionary<double, IList<Line>> linesBySlope, Line line)
		{
			double key = Line.FloorToNearestEpsilon(line.Slope);
			int count = CountEquivalentLines(linesBySlope.ContainsKey(key) ? linesBySlope[key] : null, line);
			count += CountEquivalentLines(linesBySlope.ContainsKey(key - Line.epsilon) ? linesBySlope[key - Line.epsilon] : null, line);
			count += CountEquivalentLines(linesBySlope.ContainsKey(key + Line.epsilon) ? linesBySlope[key + Line.epsilon] : null, line);
			return count;
		}

		/* Count lines within an array of lines which are "equivalent" (slope and y-intercept are within an epsilon value) to a given line */
		public static int CountEquivalentLines(IList<Line> lines, Line line)
		{
			if (lines == null)
			{
				return 0;
			}

			int count = 0;
			foreach (Line parallelLine in lines)
			{
				if (parallelLine.IsEquivalent(line))
				{
					count++;
				}
			}
			return count;
		}



		public static GraphPoint[] CreatePoints()
		{
			int n_points = 100;
			Console.WriteLine("Points on Graph\n***************");
			GraphPoint[] points = new GraphPoint[n_points - 1];
			for (int i = 0; i < n_points / 2; i++)
			{
				GraphPoint p = new GraphPoint(i, 2.3 * ((double)i) + 20.0);
				points[i] = p;
				Console.WriteLine(p.ToString());
			}
			for (int i = 0; i < n_points / 2 - 1; i++)
			{
				GraphPoint p = new GraphPoint(i, 3.0 * ((double)i) + 1.0);
				points[n_points / 2 + i] = p;
				Console.WriteLine(p.ToString());
			}
			Console.WriteLine("****************\n");
			return points;
		}

		public static int Validate(Line line, GraphPoint[] points)
		{
			int count = 0;
			for (int i = 0; i < points.Length; i++)
			{
				for (int j = i + 1; j < points.Length; j++)
				{
					Line other = new Line(points[i], points[j]);
					if (line.IsEquivalent(other))
					{
						count++;
					}
				}
			}
			return count;
		}
		public override void Run()
        {
			GraphPoint[] points = CreatePoints();
			Line line = FindBestLine(points);
			line.Print();
			Console.WriteLine(Validate(line, points));
		}
    }
}
