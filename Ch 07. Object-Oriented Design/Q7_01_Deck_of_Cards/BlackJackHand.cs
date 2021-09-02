using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_01_Deck_of_Cards
{
    public class BlackJackHand : Hand<BlackJackCard>
    {
        public BlackJackHand()
        {

        }

        public int Score()
        {
            IList<int> scores = PossibleScores();
            int maxUnder = int.MinValue;
            int minOver = int.MaxValue;
            foreach (int score in scores)
            {
                if (score > 21 && score < minOver)
                {
                    minOver = score;
                }
                else if (score <= 21 && score > maxUnder)
                {
                    maxUnder = score;
                }
            }
            return maxUnder == int.MinValue ? minOver : maxUnder;
        }

        private IList<int> PossibleScores()
        {
            IList<int> scores = new List<int>();
            if (cards.Count == 0)
            {
                return scores;
            }
            foreach (BlackJackCard card in cards)
            {
                AddCardToScoreList(card, scores);
            }
            return scores;
        }

        private void AddCardToScoreList(BlackJackCard card, IList<int> scores)
        {
            if (scores.Count == 0)
            {
                scores.Add(0);
            }
            int length = scores.Count;
            for (int i = 0; i < length; i++)
            {
                int score = scores[i];
                scores[i] = score + card.MinValue();
                if (card.MinValue() != card.MaxValue())
                {
                    scores.Add(score + card.MaxValue());
                }
            }
        }

        public bool Busted()
        {
            return Score() > 21;
        }

        public bool Is21()
        {
            return Score() == 21;
        }

        public bool IsBlackJack()
        {
            if (cards.Count != 2)
            {
                return false;
            }
            BlackJackCard first = cards[0];
            BlackJackCard second = cards[1];
            return (first.IsAce() && second.IsFaceCard()) || (second.IsAce() && first.IsFaceCard());
        }
    }
}
