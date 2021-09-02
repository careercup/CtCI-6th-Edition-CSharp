using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_01_Deck_of_Cards
{
	public class Hand<T>
		where T: Card
	{
		protected IList<T> cards = new List<T>();

		public int Score()
		{
			int score = 0;
			foreach (T card in cards)
			{
				score += card.Value();
			}
			return score;
		}

		public void AddCard(T card)
		{
			cards.Add(card);
		}

		public void Print()
		{
			foreach (Card card in cards)
			{
				card.Print();
			}
		}
	}
}
