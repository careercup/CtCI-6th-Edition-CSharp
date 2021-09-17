using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_04_Tic_Tac_Win
{
	// 方案2:  若知道最後一步
	public class Q16_04_Tic_Tac_WinB : Question
    {
		public static Piece HasWon(Piece[][] board, int row, int column)
		{
			if (board.Length != board[0].Length) return Piece.Empty;

			Piece piece = board[row][column];

			if (piece == Piece.Empty) return Piece.Empty;
			if (HasWonRow(board, row) || HasWonColumn(board, column))
			{
				return piece;
			}

			if (row == column && HasWonDiagonal(board, 1))
			{
				return piece;
			}

			if (row == (board.Length - column - 1) && HasWonDiagonal(board, -1))
			{
				return piece;
			}

			return Piece.Empty;
		}

		public static bool HasWonRow(Piece[][] board, int row)
		{
			for (int c = 1; c < board[row].Length; c++)
			{
				if (board[row][c] != board[row][0])
				{
					return false;
				}
			}
			return true;
		}

		public static bool HasWonColumn(Piece[][] board, int column)
		{
			for (int r = 1; r < board.Length; r++)
			{
				if (board[r][column] != board[0][column])
				{
					return false;
				}
			}
			return true;
		}

		public static bool HasWonDiagonal(Piece[][] board, int direction)
		{
			int row = 0;
			int column = direction == 1 ? 0 : board.Length - 1;
			Piece first = board[0][column];
			for (int i = 0; i < board.Length; i++)
			{
				if (board[row][column] != first)
				{
					return false;
				}
				row += 1;
				column += direction;
			}
			return true;
		}

		public override void Run()
        {
			int N = 3;
			int[][] board_t = AssortedMethods.RandomMatrix(N, N, 0, 2);

			board_t[1][1] = board_t[0][2];
			board_t[2][0] = board_t[0][2];

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

			Piece p1 = HasWon(board, 0, 2);

			Console.WriteLine(p1);
			AssortedMethods.PrintMatrix(board_t);
		}
    }
}
