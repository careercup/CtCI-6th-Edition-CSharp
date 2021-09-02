using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_10_Minesweeper
{
    public class Board
    {
        private int nRows;
        private int nColumns;
        private int nBombs = 0;
        private Cell[][] cells;
        private Cell[] bombs;
        private int numUnexposedRemaining;


        public Board(int r, int c, int b)
        {
            nRows = r;
            nColumns = c;
            nBombs = b;

            InitializeBoard();
            ShuffleBoard();
            SetNumberedCells();

            numUnexposedRemaining = nRows * nColumns - nBombs;
        }

        private void InitializeBoard()
        {
            cells = new Cell[nRows][];
            bombs = new Cell[nBombs];
            for (int r = 0; r < nRows; r++)
            {
                cells[r] = new Cell[nColumns];
                for (int c = 0; c < nColumns; c++)
                {
                    cells[r][c] = new Cell(r, c);
                }
            }

            for (int i = 0; i < nBombs; i++)
            {
                int r = i / nColumns;
                int c = (i - r * nColumns) % nColumns;
                bombs[i] = cells[r][c];
                bombs[i].SetBomb(true);
            }
        }

        private void ShuffleBoard()
        {
            int nCells = nRows * nColumns;
            Random random = new Random();
            for (int index1 = 0; index1 < nCells; index1++)
            {
                int index2 = index1 + random.Next(nCells - index1);
                if (index1 != index2)
                {
                    /* Get cell at index1. */
                    int row1 = index1 / nColumns;
                    int column1 = (index1 - row1 * nColumns) % nColumns;
                    Cell cell1 = cells[row1][column1];

                    /* Get cell at index2. */
                    int row2 = index2 / nColumns;
                    int column2 = (index2 - row2 * nColumns) % nColumns;
                    Cell cell2 = cells[row2][column2];

                    /* Swap. */
                    cells[row1][column1] = cell2;
                    cell2.SetRowAndColumn(row1, column1);
                    cells[row2][column2] = cell1;
                    cell1.SetRowAndColumn(row2, column2);
                }
            }
        }

        private bool InBounds(int row, int column)
        {
            return row >= 0 && row < nRows && column >= 0 && column < nColumns;
        }

        /* Set the cells around the bombs to the right number. Although 
		 * the bombs have been shuffled, the reference in the bombs array
		 * is still to same object. */
        private void SetNumberedCells()
        {
            int[][] deltas = new int[][]{ // Offsets of 8 surrounding cells
				new int [] {-1, -1},
                new int [] {-1, 0},
                new int [] {-1, 1},
                new int [] { 0, -1},
                new int [] { 0, 1},
                new int [] { 1, -1},
                new int [] { 1, 0},
                new int [] { 1, 1}
            };
            foreach (Cell bomb in bombs)
            {
                int row = bomb.GetRow();
                int col = bomb.GetColumn();
                foreach (int[] delta in deltas)
                {
                    int r = row + delta[0];
                    int c = col + delta[1];
                    if (InBounds(r, c))
                    {
                        cells[r][c].IncrementNumber();
                    }
                }
            }
        }

        public void PrintBoard(bool showUnderside)
        {
            Console.WriteLine();
            Console.Write("   ");
            for (int i = 0; i < nColumns; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < nColumns; i++)
            {
                Console.Write("--");
            }
            Console.WriteLine();
            for (int r = 0; r < nRows; r++)
            {
                Console.Write(r + "| ");
                for (int c = 0; c < nColumns; c++)
                {
                    if (showUnderside)
                    {
                        Console.Write(cells[r][c].GetUndersideState());
                    }
                    else
                    {
                        Console.Write(cells[r][c].GetSurfaceState());
                    }
                }
                Console.WriteLine();
            }
        }

        private bool FlipCell(Cell cell)
        {
            if (!cell.IsExposed() && !cell.IsGuess())
            {
                cell.Flip();
                numUnexposedRemaining--;
                return true;
            }
            return false;
        }

        public void ExpandBlank(Cell cell)
        {
            int[][] deltas = new int[][]{
                new int [] {-1, -1},
                new int [] {-1, 0},
                new int [] {-1, 1},
                new int [] { 0, -1},
                new int [] { 0, 1},
                new int [] { 1, -1},
                new int [] { 1, 0},
                new int [] { 1, 1}
        };

            Queue<Cell> toExplore = new Queue<Cell>();
            toExplore.Enqueue(cell);

            while (toExplore.Count > 0)
            {
                Cell current = toExplore.Dequeue();

                foreach (int[] delta in deltas)
                {
                    int r = current.GetRow() + delta[0];
                    int c = current.GetColumn() + delta[1];

                    if (InBounds(r, c))
                    {
                        Cell neighbor = cells[r][c];
                        if (FlipCell(neighbor) && neighbor.IsBlank())
                        {
                            toExplore.Enqueue(neighbor);
                        }
                    }
                }
            }
        }

        public UserPlayResult PlayFlip(UserPlay play)
        {
            Cell cell = GetCellAtLocation(play);
            if (cell == null)
            {
                return new UserPlayResult(false, GameState.RUNNING);
            }

            if (play.IsGuess())
            {
                bool guessResult = cell.ToggleGuess();
                return new UserPlayResult(guessResult, GameState.RUNNING);
            }

            bool result = FlipCell(cell);

            if (cell.IsBomb())
            {
                return new UserPlayResult(result, GameState.LOST);
            }

            if (cell.IsBlank())
            {
                ExpandBlank(cell);
            }

            if (numUnexposedRemaining == 0)
            {
                return new UserPlayResult(result, GameState.WON);
            }

            return new UserPlayResult(result, GameState.RUNNING);
        }

        public Cell GetCellAtLocation(UserPlay play)
        {
            int row = play.GetRow();
            int col = play.GetColumn();
            if (!InBounds(row, col))
            {
                return null;
            }
            return cells[row][col];
        }

        public int GetNumRemaining()
        {
            return numUnexposedRemaining;
        }
    }
}
