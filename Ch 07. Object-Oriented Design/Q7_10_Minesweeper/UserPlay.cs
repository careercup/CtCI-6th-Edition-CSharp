using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_10_Minesweeper
{
    public class UserPlay
    {
        private int row;
        private int column;
        private bool isGuess;

        private UserPlay(int r, int c, bool guess)
        {
            SetRow(r);
            SetColumn(c);
            isGuess = guess;
        }

        public static UserPlay FromString(string input)
        {
            bool isGuess = false;

            if (input.Length > 0 && input[0] == 'B')
            {
                isGuess = true;
                input = input.Substring(1);
            }

            if (!Regex.IsMatch(input, "\\d* \\d+"))
            {
                return null;
            }

            string[] parts = input.Split(" ");
            try
            {
                int r = Convert.ToInt32(parts[0]);
                int c = Convert.ToInt32(parts[1]);
                return new UserPlay(r, c, isGuess);
            }
            catch (FormatException e)
            {
                return null;
            }
        }

        public bool IsGuess()
        {
            return isGuess;
        }

        public bool IsMove()
        {
            return !IsMove();
        }

        public int GetColumn()
        {
            return column;
        }

        public void SetColumn(int column)
        {
            this.column = column;
        }

        public int GetRow()
        {
            return row;
        }

        public void SetRow(int row)
        {
            this.row = row;
        }
    }
}
