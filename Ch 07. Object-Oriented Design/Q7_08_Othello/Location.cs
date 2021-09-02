using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_08_Othello
{
	public class Location
	{
		private int row;
		private int column;
		public Location(int r, int c)
		{
			row = r;
			column = c;
		}

		public bool IsSameAs(int r, int c)
		{
			return row == r && column == c;
		}

		public int GetRow()
		{
			return row;
		}

		public int GetColumn()
		{
			return column;
		}
	}
}
