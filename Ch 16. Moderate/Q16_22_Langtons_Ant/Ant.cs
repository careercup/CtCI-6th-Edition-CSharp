using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_22_Langtons_Ant
{
	public class Ant
	{
		public Position Position { get; private set; } = new Position(0, 0);
		public Orientation Orientation { get; private set; } = Orientation.right;

		public void Turn(bool clockwise)
		{
			Orientation = Orientation.GetTurn(clockwise);
		}

		public void Move()
		{
			if (Orientation == Orientation.left)
			{
				Position.Column--;
			}
			else if (Orientation == Orientation.right)
			{
				Position.Column++;
			}
			else if (Orientation == Orientation.up)
			{
				Position.Row--;
			}
			else if (Orientation == Orientation.down)
			{
				Position.Row++;
			}
		}

		public void AdjustPosition(int shiftRow, int shiftColumn)
		{
			Position.Row += shiftRow;
			Position.Column += shiftColumn;
		}
	}
}
