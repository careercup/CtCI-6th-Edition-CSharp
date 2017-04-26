using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter16
{
    public class Q16_04_Tic_Tac_Toe_Win : Question
    {
        public class TicTacToe
        {
            const int BoardSize = 3;
            public enum Piece
            {
                NA = 0,
                X,
                O
            }
            Piece[,] _matrix = new Piece[BoardSize, BoardSize];
            Piece _hasWon = Piece.NA;
            Piece _whosMove;

            public TicTacToe(Piece whosMove = TicTacToe.Piece.X)
            {
                if (whosMove == Piece.NA) throw new ArgumentException("Invalid start piece");
                _whosMove = whosMove;
            }

            public void Place(int r, int c, Piece piece)
            {
                if (r < 0 || r >= BoardSize || c < 0 || c >= BoardSize) throw new ArgumentException("location is out of bounds");
                if (piece != _whosMove) throw new ArgumentException("Wrong player");
                if (_matrix[r, c] != Piece.NA) throw new ArgumentException("Square already occupied");
                if (_hasWon != Piece.NA) throw new ArgumentException("Game has already ended");

                _matrix[r, c] = piece;
                _whosMove = piece == Piece.X ? Piece.O : Piece.X;
                SetWinnerIfAny(r, c, piece);
            }

            private void SetWinnerIfAny(int r, int c, Piece piece)
            {
                if (CheckHasWonRow(r) || CheckHasWonColumn(c) ||
                    CheckHasWonDiagonally() || CheckHasWonDiagonallyReverse())
                    _hasWon = piece;
            }

            private bool CheckHasWonDiagonallyReverse()
            {
                return _matrix[0, 2] == _matrix[1, 1] && _matrix[1, 1] == _matrix[2, 0];
            }

            private bool CheckHasWonDiagonally()
            {
                return _matrix[0, 0] == _matrix[1, 1] && _matrix[1, 1] == _matrix[2, 2];
            }

            private bool CheckHasWonColumn(int c)
            {
                return _matrix[0, c] == _matrix[1, c] && _matrix[1, c] == _matrix[2, c];
            }

            private bool CheckHasWonRow(int r)
            {
                return _matrix[r, 0] == _matrix[r, 1] && _matrix[r, 1] == _matrix[r, 2];
            }

            public Piece GetWinner()
            {
                return _hasWon;
            }
        }

        public override void Run()
        {
            var ticTacToa = new TicTacToe();
            ticTacToa.Place(1, 1, TicTacToe.Piece.X);
            Console.WriteLine($"Has winner :{ticTacToa.GetWinner()}");

            ticTacToa.Place(1, 2, TicTacToe.Piece.O);
            Console.WriteLine($"Has winner :{ticTacToa.GetWinner()}");

            ticTacToa.Place(0, 2, TicTacToe.Piece.X);
            Console.WriteLine($"Has winner :{ticTacToa.GetWinner()}");

            ticTacToa.Place(0, 1, TicTacToe.Piece.O);
            Console.WriteLine($"Has winner :{ticTacToa.GetWinner()}");

            ticTacToa.Place(2, 0, TicTacToe.Piece.X);
            Console.WriteLine($"Has winner :{ticTacToa.GetWinner()}");
        }
    }
}
