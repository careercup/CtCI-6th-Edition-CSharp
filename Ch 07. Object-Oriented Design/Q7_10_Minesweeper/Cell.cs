using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_10_Minesweeper
{
    public class Cell
    {
        private int row;
        private int column;
        private bool isBomb;
        private int number;
        private bool isExposed = false;
        private bool isGuess = false;

        public Cell(int r, int c)
        {
            isBomb = false;
            number = 0;
            row = r;
            column = c;
        }

        public void SetRowAndColumn(int r, int c)
        {
            row = r;
            column = c;
        }

        public void SetBomb(bool bomb)
        {
            isBomb = bomb;
            number = -1;
        }

        public void IncrementNumber()
        {
            number++;
        }

        public int GetRow()
        {
            return row;
        }

        public int GetColumn()
        {
            return column;
        }

        public bool IsBomb()
        {
            return isBomb;
        }

        public bool IsBlank()
        {
            return number == 0;
        }

        public bool IsExposed()
        {
            return isExposed;
        }

        public bool Flip()
        {
            isExposed = true;
            return !isBomb;
        }

        public bool ToggleGuess()
        {
            if (!isExposed)
            {
                isGuess = !isGuess;
            }
            return isGuess;
        }

        public bool IsGuess()
        {
            return isGuess;
        }

        public override string ToString()
        {
            return GetUndersideState();
        }

        public string GetSurfaceState()
        {
            if (isExposed)
            {
                return GetUndersideState();
            }
            else if (isGuess)
            {
                return "B ";
            }
            else
            {
                return "? ";
            }
        }

        public string GetUndersideState()
        {
            if (isBomb)
            {
                return "* ";
            }
            else if (number > 0)
            {
                return number.ToString() + " ";
            }
            else
            {
                return "  ";
            }
        }
    }
}
