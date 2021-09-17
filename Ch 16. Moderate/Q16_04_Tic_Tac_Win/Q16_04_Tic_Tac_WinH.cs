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
	// IEnumerator
	public class Q16_04_Tic_Tac_WinH : Question
    {
		public static Piece HasWon(Piece[][] board)
		{
			if (board.Length != board[0].Length) return Piece.Empty;
			int size = board.Length;

			IList<PositionIEnumerator> instructions = new List<PositionIEnumerator>();
			for (int i = 0; i < board.Length; i++)
			{
				instructions.Add(new PositionIEnumerator(new Position(0, i), 1, 0, size));
				instructions.Add(new PositionIEnumerator(new Position(i, 0), 0, 1, size));
			}
			instructions.Add(new PositionIEnumerator(new Position(0, 0), 1, 1, size));
			instructions.Add(new PositionIEnumerator(new Position(0, size - 1), 1, -1, size));

			foreach (PositionIEnumerator iterator in instructions)
			{
				Piece winner = HasWon(board, iterator);
				if (winner != Piece.Empty)
				{
					return winner;
				}
			}
			return Piece.Empty;
		}

		public static Piece HasWon(Piece[][] board, PositionIEnumerator iterator)
		{
			iterator.MoveNext();
			Position firstPosition = iterator.Current;
			Piece first = board[firstPosition.Row][firstPosition.Column];
			while (iterator.MoveNext())
			{
				Position position = iterator.Current;
				if (board[position.Row][position.Column] != first)
				{
					return Piece.Empty;
				}
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
