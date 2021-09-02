using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_08_Othello
{
	public class Game
	{
		private Player[] players;
		private static Game instance;
		private Board board;
		private readonly int ROWS = 10;
		private readonly int COLUMNS = 10;

		private Game()
		{
			board = new Board(ROWS, COLUMNS);
			players = new Player[2];
			players[0] = new Player(Color.Black);
			players[1] = new Player(Color.White);
			Automator.GetInstance().Initialize(players); // used for testing
		}

		public static Game GetInstance()
		{
			if (instance == null)
			{
				instance = new Game();
			}
			return instance;
		}

		public Board GetBoard()
		{
			return board;
		}
	}
}
