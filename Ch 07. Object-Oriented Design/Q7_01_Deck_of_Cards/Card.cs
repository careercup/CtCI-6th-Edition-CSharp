using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_01_Deck_of_Cards
{
	public abstract class Card
	{
		private bool available = true;

		/* number or face that's on card - a number 2 through 10, 
		 * or 11 for Jack, 12 for Queen, 13 for King, or 1 for Ace 
		 */
		protected int faceValue;
		protected Suit suit;

		public Card(int c, Suit s)
		{
			faceValue = c;
			suit = s;
		}

		public abstract int Value();

		public Suit GetSuit()
		{
			return suit;
		}

		/* returns whether or not the card is available to be given out to someone */
		public bool IsAvailable()
		{
			return available;
		}

		public void MarkUnavailable()
		{
			available = false;
		}

		public void MarkAvailable()
		{
			available = true;
		}

		public void Print()
		{
			string[] faceValues = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
			Console.Write(faceValues[faceValue - 1]);
			switch ((SuitEnum)suit.GetValue())
			{
				case SuitEnum.Club:
					Console.Write("c");
					break;
				case SuitEnum.Heart:
					Console.Write("h");
					break;
				case SuitEnum.Diamond:
					Console.Write("d");
					break;
				case SuitEnum.Spade:
					Console.Write("s");
					break;
			}
			Console.Write(" ");
		}
	}
}
