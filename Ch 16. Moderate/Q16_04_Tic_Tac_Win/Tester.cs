using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_04_Tic_Tac_Win
{
	public class Tester
	{
		public static Piece ConvertIntToPiece(int i)
		{
			if (i == 1)
			{
				return Piece.Blue;
			}
			else if (i == 2)
			{
				return Piece.Red;
			}
			else
			{
				return Piece.Empty;
			}
		}




		public static Piece HasWonB(Piece[][] board)
		{
			for (int i = 0; i < board.Length; i++)
			{
				for (int j = 0; j < board[0].Length; j++)
				{
					Piece winner = Q16_04_Tic_Tac_WinB.HasWon(board, i, j);
					if (winner != Piece.Empty)
					{
						return winner;
					}
				}
			}
			return Piece.Empty;
		}

        public static void Main(string[] args)
        {
            for (int k = 0; k < 100; k++)
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
                        board[i][j] = ConvertIntToPiece(x);
                    }
                }
                //AssortedMethods.printMatrix(board_t);
                Piece p1 = HasWonB(board);
                Piece p2 = Q16_04_Tic_Tac_WinC.HasWon(board);
                Piece p3 = Q16_04_Tic_Tac_WinD.HasWon(board);
                Piece p4 = Q16_04_Tic_Tac_WinE.HasWon(board);
                Piece p5 = Q16_04_Tic_Tac_WinF.HasWon(board);
                Piece p6 = Q16_04_Tic_Tac_WinG.HasWon(board);
                Piece p7 = Q16_04_Tic_Tac_WinH.HasWon(board);
                //Console.WriteLine(p + " " + p2);
                if (p1 != p2 || p2 != p3 || p3 != p4 || p4 != p5 || p5 != p6 || p6 != p7)
                {
                    Console.WriteLine(p1 + " " + p2 + " " + p3 + " " + p4 + " " + p5 + " " + p6 + " " + p7);
                    AssortedMethods.PrintMatrix(board_t);
                }
            }

            for (int k = 0; k < 100; k++)
            {
                int N = 4;
                int[][] board_t = AssortedMethods.RandomMatrix(N, N, 0, 2);
                Piece[][] board = new Piece[N][];
                for (int i = 0; i < N; i++)
                {
                    board[i] = new Piece[N];
                    for (int j = 0; j < N; j++)
                    {
                        int x = board_t[i][j];
                        board[i][j] = ConvertIntToPiece(x);
                    }
                }
                //AssortedMethods.printMatrix(board_t);
                Piece p3 = HasWonB(board);
                Piece p4 = Q16_04_Tic_Tac_WinE.HasWon(board);
                Piece p5 = Q16_04_Tic_Tac_WinF.HasWon(board);
                Piece p6 = Q16_04_Tic_Tac_WinG.HasWon(board);
                Piece p7 = Q16_04_Tic_Tac_WinH.HasWon(board);
                //Console.WriteLine(p + " " + p2);
                if (p3 != p4 || p4 != p5 || p5 != p6 || p6 != p7)
                {
                    Console.WriteLine(p3 + " " + p4 + " " + p5 + " " + p6 + " " + p7);
                    AssortedMethods.PrintMatrix(board_t);
                }
            }
        }

    }
}
