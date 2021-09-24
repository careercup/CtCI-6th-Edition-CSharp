using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_23_Max_Black_Square
{
    public class Subsquare
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public int Size { get; private set; }
        public Subsquare(int r, int c, int sz)
        {
            Row = r;
            Column = c;
            Size = sz;
        }

        public void Print()
        {
            Console.WriteLine("(" + Row + ", " + Column + ", " + Size + ")");
        }
    }
}
