using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_10_Minesweeper
{
	public class Game
	{
		private Board board;
		private int rows;
		private int columns;
		private int bombs;
		private GameState state;

		public Game(int r, int c, int b)
		{
			rows = r;
			columns = c;
			bombs = b;
			state = GameState.RUNNING;
		}

		public bool Initialize()
		{
			if (board == null)
			{
				board = new Board(rows, columns, bombs);
				board.PrintBoard(true);
				return true;
			}
			else
			{
				Console.WriteLine("Game has already been initialized.");
				return false;
			}
		}

		public bool Start()
		{
			if (board == null)
			{
				Initialize();
			}
			return PlayGame();
		}

		public void PrintGameState()
		{
			if (state == GameState.LOST)
			{
				board.PrintBoard(true);
				Console.WriteLine("FAIL");
			}
			else if (state == GameState.WON)
			{
				board.PrintBoard(true);
				Console.WriteLine("WIN");
			}
			else
			{
				Console.WriteLine("Number remaining: " + board.GetNumRemaining());
				board.PrintBoard(false);
			}
		}

		private bool PlayGame()
		{
			PrintGameState();

			while (state == GameState.RUNNING)
			{
				string input = Console.ReadLine();
				if (input.Equals("exit"))
				{
					return false;
				}

				UserPlay play = UserPlay.FromString(input);
				if (play == null)
				{
					continue;
				}

				UserPlayResult result = board.PlayFlip(play);
				if (result.SuccessfulMove())
				{
					state = result.GetResultingState();
				}
				else
				{
					Console.WriteLine("Could not flip cell (" + play.GetRow() + "," + play.GetColumn() + ").");
				}
				PrintGameState();
			}
			return true;
		}


	}
}
