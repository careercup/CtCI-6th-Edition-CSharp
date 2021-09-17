using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_22_Langtons_Ant
{
    public enum Orientation
    {
        left,
        up,
        right,
        down
    }

    public static class OrientationExtend
    {
        public static Orientation GetTurn(this Orientation o , bool clockwise)
        {
            if (o == Orientation.left)
            {
                return clockwise ? Orientation.up : Orientation.down;
            }
            else if (o == Orientation.up)
            {
                return clockwise ? Orientation.right : Orientation.left;
            }
            else if (o == Orientation.right)
            {
                return clockwise ? Orientation.down : Orientation.up;
            }
            else
            { // down
                return clockwise ? Orientation.left : Orientation.right;
            }
        }

        public static string ToString(this Orientation o)
        {
            if (o == Orientation.left)
            {
                return "\u2190";
            }
            else if (o == Orientation.up)
            {
                return "\u2191";
            }
            else if (o == Orientation.right)
            {
                return "\u2192";
            }
            else
            { // down
                return "\u2193";
            }
        }
    }
}
