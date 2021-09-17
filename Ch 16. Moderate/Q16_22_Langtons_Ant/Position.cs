using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_22_Langtons_Ant
{
	public class Position
	{
		public int Row { get; set; }
		public int Column { get; set; }

		public Position(int row, int column)
		{
			this.Row = row;
			this.Column = column;
		}

		public override bool Equals(Object o)
		{
			if (o is Position) {
				Position p = (Position)o;
				return p.Row == Row && p.Column == Column;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (Row * 31) ^ Column;
		}

		public Position Clone()
		{
			return new Position(Row, Column);
		}
	}
}
