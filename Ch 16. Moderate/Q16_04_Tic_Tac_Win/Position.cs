using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_04_Tic_Tac_Win
{
    public class Position
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}
