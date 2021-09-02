using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_01_Deck_of_Cards
{
	public class Deck<T>
		where T: Card
	{
		private IList<T> cards;
		private int dealtIndex = 0; // marks first undealt card

		public Deck()
		{
		}

		public void SetDeckOfCards(IList<T> deckOfCards)
		{
			cards = deckOfCards;
		}

		public void Shuffle()
		{
			for (int i = 0; i < cards.Count; i++)
			{
				int j = AssortedMethods.RandomIntInRange(Math.Min(i, cards.Count - i - 1), Math.Max(i, cards.Count - i - 1));
				T card1 = cards[i];
				T card2 = cards[j];
				cards[i]= card2;
				cards[j] = card1;
			}
		}

		public int RemainingCards()
		{
			return cards.Count - dealtIndex;
		}

		public T[] DealHand(int number)
		{
			if (RemainingCards() < number)
			{
				return null;
			}

			T[] hand = (T[])new Card[number];
			int count = 0;
			while (count < number)
			{
				T card = DealCard();
				if (card != null)
				{
					hand[count] = card;
					count++;
				}
			}

			return hand;
		}

		public T DealCard()
		{
			if (RemainingCards() == 0)
			{
				return null;
			}

			T card = cards[dealtIndex];
			card.MarkUnavailable();
			dealtIndex++;

			return card;
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
