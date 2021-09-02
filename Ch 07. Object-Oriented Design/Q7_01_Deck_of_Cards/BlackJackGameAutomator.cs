using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_01_Deck_of_Cards
{
	public class BlackJackGameAutomator
	{
		private Deck<BlackJackCard> deck;
		private BlackJackHand[] hands;
		private static int HIT_UNTIL = 16;

		public BlackJackGameAutomator(int numPlayers)
		{
			hands = new BlackJackHand[numPlayers];
			for (int i = 0; i < numPlayers; i++)
			{
				hands[i] = new BlackJackHand();
			}
		}

		public bool DealInitial()
		{
			foreach (BlackJackHand hand in hands)
			{
				BlackJackCard card1 = deck.DealCard();
				BlackJackCard card2 = deck.DealCard();
				if (card1 == null || card2 == null)
				{
					return false;
				}
				hand.AddCard(card1);
				hand.AddCard(card2);
			}
			return true;
		}

		public IList<int> GetBlackJacks()
		{
			IList<int> winners = new List<int>();
			for (int i = 0; i < hands.Length; i++)
			{
				if (hands[i].IsBlackJack())
				{
					winners.Add(i);
				}
			}
			return winners;
		}

		public bool PlayHand(int i)
		{
			BlackJackHand hand = hands[i];
			return PlayHand(hand);
		}

		public bool PlayHand(BlackJackHand hand)
		{
			while (hand.Score() < HIT_UNTIL)
			{
				BlackJackCard card = deck.DealCard();
				if (card == null)
				{
					return false;
				}
				hand.AddCard(card);
			}
			return true;
		}

		public bool PlayAllHands()
		{
			foreach (BlackJackHand hand in hands)
			{
				if (!PlayHand(hand))
				{
					return false;
				}
			}
			return true;
		}

		public IList<int> GetWinners()
		{
			IList<int> winners = new List<int>();
			int winningScore = 0;
			for (int i = 0; i < hands.Length; i++)
			{
				BlackJackHand hand = hands[i];
				if (!hand.Busted())
				{
					if (hand.Score() > winningScore)
					{
						winningScore = hand.Score();
						winners.Clear();
						winners.Add(i);
					}
					else if (hand.Score() == winningScore)
					{
						winners.Add(i);
					}
				}
			}
			return winners;
		}

		public void InitializeDeck()
		{
			IList<BlackJackCard> cards = new List<BlackJackCard>();
			for (int i = 1; i <= 13; i++)
			{
				for (int j = 0; j <= 3; j++)
				{
					var suit = Suit.GetSuitFromValue(j);
					BlackJackCard card = new BlackJackCard(i, suit);
					cards.Add(card);
				}
			}

			deck = new Deck<BlackJackCard>();
			deck.SetDeckOfCards(cards);
			deck.Shuffle();
		}

		public void PrintHandsAndScore()
		{
			for (int i = 0; i < hands.Length; i++)
			{
				Console.Write("Hand " + i + " (" + hands[i].Score() + "): ");
				hands[i].Print();
				Console.WriteLine("");
			}
		}
	}
}
