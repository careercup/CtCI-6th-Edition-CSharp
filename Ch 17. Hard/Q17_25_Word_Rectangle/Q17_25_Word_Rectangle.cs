using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_25_Word_Rectangle
{
    public class Q17_25_Word_Rectangle
    {
        private int maxWordLength;
        private WordGroup[] groupList;
        private Trie[] trieList;

        public Q17_25_Word_Rectangle(string[] list)
        {
            groupList = WordGroup.CreateWordGroups(list);
            maxWordLength = groupList.Length;
            // Initialize trieList to store trie of groupList[i] at ith position.
            trieList = new Trie[maxWordLength];
        }

		/* This function finds a rectangle of letters of the largest 
		 * possible area (length x breadth) such that every row forms a 
		 * word (reading left to right) from the list and every column 
		 * forms a word (reading top to bottom) from the list. 
		 */
		public Rectangle MaxRectangleA()
		{
			// The dimensions of the largest possible rectangle.
			int maxSize = maxWordLength * maxWordLength;

			for (int z = maxSize; z > 0; z--)
			{
				// Find out all pairs i,j less than maxWordLength 
				// such that i * j = z
				for (int i = 1; i <= maxWordLength; i++)
				{
					if (z % i == 0)
					{
						int j = z / i;
						if (j <= maxWordLength)
						{
							// Check if a Rectangle of length i and height 
							// j can be created. 
							Rectangle rectangle = MakeRectangle(i, j);
							if (rectangle != null)
							{
								return rectangle;
							}
						}
					}
				}
			}
			return null;
		}

		/* This function takes the length and height of a rectangle as
		 * arguments. It tries to form a rectangle of the given length and 
		 * height using words of the specified length as its rows, in which 
		 * words whose length is the specified height form the columns. It 
		 * returns the rectangle so formed, and null if such a rectangle 
		 * cannot be formed.
		 */
		private Rectangle MakeRectangle(int length, int height)
		{
			if (groupList[length - 1] == null || groupList[height - 1] == null)
			{
				return null;
			}
			if (trieList[height - 1] == null)
			{
				IList<string> words = groupList[height - 1].GetWords();
				trieList[height - 1] = new Trie((List<string>)words);
			}
			return MakePartialRectangle(length, height, new Rectangle(length));
		}


		/* This function recursively tries to form a rectangle with words
		 * of length l from the dictionary as rows and words of length h
		 * from the dictionary as columns. To do so, we start with an empty
		 * rectangle and add in a word with length l as the first row. We
		 * then check the trie of words of length h to see if each partial
		 * column is a prefix of a word with length h. If so we branch
		 * recursively and check the next word till we've formed a complete
		 * rectangle. When we have a complete rectangle check if every
		 * column is a word in the dictionary.
		 */
		private Rectangle MakePartialRectangle(int l, int h, Rectangle rectangle)
		{

			// Check if we have formed a complete rectangle by seeing if each column
			// is in the dictionary
			if (rectangle.Height == h)
			{
				if (rectangle.IsComplete(l, h, groupList[h - 1]))
				{
					return rectangle;
				}
				else
				{
					return null;
				}
			}

			// If the rectangle is not empty, validate that each column is a
			// substring of a word of length h in the dictionary using the
			// trie of words of length h.
			if (!rectangle.IsPartialOK(l, trieList[h - 1]))
			{
				return null;
			}

			// For each word of length l, try to make a new rectangle by adding
			// the word to the existing rectangle.
			for (int i = 0; i < groupList[l - 1].Length(); i++)
			{
				Rectangle orgPlus = rectangle.Append(groupList[l - 1].GetWord(i));
				Rectangle rect = MakePartialRectangle(l, h, orgPlus);
				if (rect != null)
				{
					return rect;
				}
			}
			return null;
		}
    }
}
