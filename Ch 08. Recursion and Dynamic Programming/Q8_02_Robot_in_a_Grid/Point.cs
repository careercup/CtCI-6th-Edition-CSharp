using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_02_Robot_in_a_Grid
{
    public class Point
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public Point(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public override string ToString()
        {
            return "(" + Row + ", " + Column + ")";
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object o)
        {
            if ((o is Point) && (((Point)o).Row == this.Row) && (((Point)o).Column == this.Column))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
