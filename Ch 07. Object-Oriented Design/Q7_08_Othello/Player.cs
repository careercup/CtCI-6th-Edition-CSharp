using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_08_Othello
{
	public class Player
	{
		private Color color;
		public Player(Color c)
		{
			color = c;
		}

		public int GetScore()
		{
			return Game.GetInstance().GetBoard().GetScoreForColor(color);
		}

		public bool PlayPiece(int row, int column)
		{
			return Game.GetInstance().GetBoard().PlaceColor(row, column, color);
		}

		public Color GetColor()
		{
			return color;
		}
	}
}
