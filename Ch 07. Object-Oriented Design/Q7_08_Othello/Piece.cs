using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_08_Othello
{
	public class Piece
	{
		private Color color;

		public Piece(Color c)
		{
			color = c;
		}

		public void Flip()
		{
			if (color == Color.Black)
			{
				color = Color.White;
			}
			else
			{
				color = Color.Black;
			}
		}

		public Color GetColor()
		{
			return color;
		}
	}
}
