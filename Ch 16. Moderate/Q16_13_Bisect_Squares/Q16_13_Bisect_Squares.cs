using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_13_Bisect_Squares
{
    public class Q16_13_Bisect_Squares : Question
    {
        public static int RandomInt(int n)
        {
            return new Random().Next();
        }

        public static void PrintLine(Line l)
        {
            Console.WriteLine(l.Start.X + "\t" + l.Start.Y);
            Console.WriteLine(l.End.X + "\t" + l.End.Y);
        }

        public static void PrintSquare(Square s)
        {
            Console.WriteLine(s.Left + "\t" + s.Top + "\t" + s.Size);
        }

        public static bool IsApproxEqual(double d1, double d2)
        {
            double epsilon = .001;
            if (Math.Abs(d1 - d2) < epsilon)
            {
                return true;
            }
            return false;
        }

        public static bool IsApproxEqual(Point p1, Point p2)
        {
            return IsApproxEqual(p1.X, p2.X) && IsApproxEqual(p1.Y, p2.Y);
        }

        public static bool DoTest(Square s1, Square s2, Point start, Point end)
        {
            Line line = s1.Cut(s2);
            bool r = (IsApproxEqual(line.Start, start) && IsApproxEqual(line.End, end)) || (IsApproxEqual(line.Start, end) && IsApproxEqual(line.End, start));
            if (!r)
            {
                PrintSquare(s1);
                PrintSquare(s2);
                PrintLine(line);
                Console.WriteLine(start.ToString());
                Console.WriteLine(end.ToString());
                Console.WriteLine();
                return r;
            }
            return r;
        }

        public static bool DoTestFull(Square s1, Square s2, Point start, Point end)
        {
            return DoTest(s1, s2, start, end) && DoTest(s2, s1, start, end);
        }

        public static void DoTests()
        {
            // Equal
            DoTestFull(new Square(1, 1, 5), new Square(1, 1, 5), new Point(3.5, 1), new Point(3.5, 6));

            // Concentric
            DoTestFull(new Square(1, 1, 5), new Square(2, 2, 3), new Point(3.5, 1), new Point(3.5, 6));

            // Partially overlapping -- side by side
            DoTestFull(new Square(10, 10, 10), new Square(8, 10, 10), new Point(8, 15), new Point(20, 15));

            // Partially overlapping -- corners
            DoTestFull(new Square(10, 10, 10), new Square(8, 7, 7), new Point(8.777777, 7), new Point(18.8888888, 20));

            // Partially overlapping -- on top of each other
            DoTestFull(new Square(10, 10, 10), new Square(8, 7, 15), new Point(8, 22), new Point(23, 7));

            // Not overlapping -- side by side
            DoTestFull(new Square(10, 10, 10), new Square(19, 25, 4), new Point(12.5, 10), new Point(22, 29));

            // Not overlapping -- on top of each other
            DoTestFull(new Square(10, 10, 10), new Square(4, 4, 3), new Point(4, 4), new Point(20, 20));

            // Contained
            DoTestFull(new Square(10, 10, 10), new Square(12, 14, 3), new Point(10, 16.66666), new Point(20, 13.333));
        }

        public override void Run()
        {
            /* For an easy way to test these, open up Square Cut Tester.xlsx
		 * in the Chapter 7, Problem 5 folder. Copy and paste the exact 
		 * output from below into the file (including all tabs).
		 */
            DoTests();
        }
    }
}
