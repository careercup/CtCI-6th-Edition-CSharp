using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_04_Tic_Tac_Win
{
    public class Check
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        private int rowIncrement, columnIncrement;
        public Check(int row, int column, int rowI, int colI)
        {
            this.Row = row;
            this.Column = column;
            this.rowIncrement = rowI;
            this.columnIncrement = colI;
        }

        public void Increment()
        {
            Row += rowIncrement;
            Column += columnIncrement;
        }

        public bool InBounds(int size)
        {
            return Row >= 0 && Column >= 0 &&
                    Row < size && Column < size;
        }
    }
}
