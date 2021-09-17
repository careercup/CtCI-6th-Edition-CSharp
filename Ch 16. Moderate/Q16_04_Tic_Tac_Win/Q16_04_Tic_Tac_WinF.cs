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
	// 遞增遞減函式
	public class Q16_04_Tic_Tac_WinF : Question
    {
		public static Piece HasWon(Piece[][] board)
		{
			Piece winner = Piece.Empty;

			/* Check rows. */
			for (int i = 0; i < board.Length; i++)
			{
				winner = HasWon(board, i, 0, 0, 1);
				if (winner != Piece.Empty)
				{
					return winner;
				}
			}

			/* Check columns. */
			for (int i = 0; i < board[0].Length; i++)
			{
				winner = HasWon(board, 0, i, 1, 0);
				if (winner != Piece.Empty)
				{
					return winner;
				}
			}

			/* Check top/left -> bottom/right diagonal. */
			winner = HasWon(board, 0, 0, 1, 1);
			if (winner != Piece.Empty)
			{
				return winner;
			}

			/* Check top/right -> bottom/left diagonal. */
			return HasWon(board, 0, board[0].Length - 1, 1, -1);
		}

		public static Piece HasWon(Piece[][] board, int row, int col, int incrementRow, int incrementCol)
		{
			Piece first = board[row][col];
			while (row < board.Length && col < board[row].Length)
			{
				if (board[row][col] != first)
				{
					return Piece.Empty;
				}
				row += incrementRow;
				col += incrementCol;
			}
			return first;
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
