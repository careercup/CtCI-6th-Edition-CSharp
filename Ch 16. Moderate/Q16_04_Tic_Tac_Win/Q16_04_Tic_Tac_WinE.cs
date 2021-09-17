using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_04_Tic_Tac_Win
{
	// 方案4:  設計 N*N 棋盤
	public class Q16_04_Tic_Tac_WinE : Question
    {
		public static Piece HasWon(Piece[][] board)
		{
			int size = board.Length;
			if (board[0].Length != size) return Piece.Empty;
			Piece first;

			/* Check rows. */
			for (int i = 0; i < size; i++)
			{
				first = board[i][0];
				if (first == Piece.Empty) continue;
				for (int j = 1; j < size; j++)
				{
					if (board[i][j] != first)
					{
						break;
					}
					else if (j == size - 1)
					{
						return first;
					}
				}
			}

			/* Check columns. */
			for (int i = 0; i < size; i++)
			{
				first = board[0][i];
				if (first == Piece.Empty) continue;
				for (int j = 1; j < size; j++)
				{
					if (board[j][i] != first)
					{
						break;
					}
					else if (j == size - 1)
					{
						return first;
					}
				}
			}

			/* Check diagonals. */
			first = board[0][0];
			if (first != Piece.Empty)
			{
				for (int i = 1; i < size; i++)
				{
					if (board[i][i] != first)
					{
						break;
					}
					else if (i == size - 1)
					{
						return first;
					}
				}
			}

			first = board[0][size - 1];
			if (first != Piece.Empty)
			{
				for (int i = 1; i < size; i++)
				{
					if (board[i][size - i - 1] != first)
					{
						break;
					}
					else if (i == size - 1)
					{
						return first;
					}
				}
			}

			return Piece.Empty;
		}

		public override void Run()
        {
			int N = 3;
			int[][] board_t = AssortedMethods.RandomMatrix(N, N, 0, 2);
			Piece[][] board = new Piece[N][];
			for (int i = 0; i < N; i++)
			{
				board[i] = new Piece[N];
				for (int j = 0; j < N; j++)
				{
					int x = board_t[i][j];
					board[i][j] = Tester.ConvertIntToPiece(x);
				}
			}

			Piece p1 = HasWon(board);

			Console.WriteLine(p1);
			AssortedMethods.PrintMatrix(board_t);
		}
    }
}
