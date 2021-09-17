using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_04_Tic_Tac_Win
{
	// 方案3: 只對 3*3 棋盤設計
	public class Q16_04_Tic_Tac_WinD : Question
    {
		public static Piece HasWon(Piece[][] board)
		{
			if (board[0][0] != Piece.Empty &&
				(HasWinner(board[0][0], board[0][1], board[0][2]) ||
				 HasWinner(board[0][0], board[1][0], board[2][0])))
			{
				return board[0][0];
			}

			if (board[2][2] != Piece.Empty &&
				(HasWinner(board[2][0], board[2][1], board[2][2]) ||
				 HasWinner(board[0][2], board[1][2], board[2][2])))
			{
				return board[2][2];
			}

			if (board[1][1] != Piece.Empty &&
				(HasWinner(board[0][0], board[1][1], board[2][2]) ||
				 HasWinner(board[0][2], board[1][1], board[2][0]) ||
				 HasWinner(board[1][0], board[1][1], board[1][2]) ||
				 HasWinner(board[0][1], board[1][1], board[2][1])))
			{
				return board[1][1];
			}

			return Piece.Empty;
		}

		public static bool HasWinner(Piece p1, Piece p2, Piece p3)
		{
			if (p1 == Piece.Empty)
			{
				return false;
			}
			return p1 == p2 && p2 == p3;
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
