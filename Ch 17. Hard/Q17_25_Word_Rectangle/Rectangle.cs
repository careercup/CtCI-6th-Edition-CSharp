using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_25_Word_Rectangle
{
    /* A class that represents a rectangular array of letters. */
    public class Rectangle
    {

        // Rectangle data.
        public int Height { get; private set; }
        public int Length { get; private set; }
        public char[][] Matrix { get; private set; }

        public Rectangle(int len)
        {
            this.Length = len;
        }

        /* Construct a rectangular array of letters of the specified length
         * and height, and backed by the specified matrix of letters. (It is
         * assumed that the length and height specified as arguments are 
         * consistent with the array argument's dimensions.)
         */
        public Rectangle(int length, int height, char[][] letters)
        {
            this.Height = letters.Length;
            this.Length = letters[0].Length;
            Matrix = letters;
        }

        /* Return the letter present at the specified location in the array.
         */
        public char GetLetter(int i, int j)
        {
            return Matrix[i][j];
        }

        public string GetColumn(int i)
        {
            char[] column = new char[Height];
            for (int j = 0; j < Height; j++)
            {
                column[j] = GetLetter(j, i);
            }
            return new string(column);
        }

        public bool IsComplete(int l, int h, WordGroup groupList)
        {
            // Check if we have formed a complete rectangle.
            if (Height == h)
            {
                // Check if each column is a word in the dictionary.
                for (int i = 0; i < l; i++)
                {
                    string col = GetColumn(i);
                    if (!groupList.ContainsWord(col))
                    {
                        return false; // Invalid rectangle.
                    }
                }
                return true; // Valid Rectangle!
            }
            return false;
        }

        public bool IsPartialOK(int l, Trie trie)
        {
            if (Height == 0)
            {
                return true;
            }
            for (int i = 0; i < l; i++)
            {
                string col = GetColumn(i);
                if (!trie.Contains(col))
                {
                    return false; // Invalid rectangle.
                }
            }
            return true;
        }

        /* If the length of the argument s is consistent with that of this
         * Rectangle object, then return a Rectangle whose matrix is constructed by
         * appending s to the underlying matrix. Otherwise, return null. The
         * underlying matrix of this Rectangle object is /not/ modified.
         */
        public Rectangle Append(string s)
        {
            if (s.Length == Length)
            {
                char[][] temp = new char[Height + 1][];
                for (int i = 0; i <= Height; i++)
                {
                    temp[i] = new char[Length];
                }
                for (int i = 0; i < Height; i++)
                {                
                    for (int j = 0; j < Length; j++)
                    {
                        temp[i][j] = Matrix[i][j];
                    }
                }

                for (int i = 0; i < Length; i++)
                {
                    temp[Height][i] = s[i];
                }

                return new Rectangle(Length, Height + 1, temp);
            }
            return null;
        }

        /* Print the rectangle out, row by row. */
        public void Print()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Write(Matrix[i][j]);
                }
                Console.WriteLine(" ");
            }
        }
    }
}
