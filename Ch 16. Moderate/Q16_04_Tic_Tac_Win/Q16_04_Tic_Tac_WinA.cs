using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_04_Tic_Tac_Win
{
	// 方案1: 若 HasWon 被呼叫多次
	public class Q16_04_Tic_Tac_WinA : Question
    {
		public static int ConvertBoardToInt(Piece[][] board)
		{
			int sum = 0;
			for (int i = 0; i < board.Length; i++)
			{
				for (int j = 0; j < board[i].Length; j++)
				{
					int value = (int)board[i][j];
					sum = sum * 3 + value;
				}
			}
			return sum;
		}

		public override void Run()
        {
			Piece[][] board = {
				new Piece[] {Piece.Empty, Piece.Empty, Piece.Empty},
				new Piece[] {Piece.Empty, Piece.Empty, Piece.Empty},
				new Piece[] {Piece.Blue, Piece.Blue, Piece.Blue}};

			int v = ConvertBoardToInt(board);
			Console.WriteLine(v);
		}
    }
}
