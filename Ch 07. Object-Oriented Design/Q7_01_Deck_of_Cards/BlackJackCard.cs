using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_01_Deck_of_Cards
{

    public class BlackJackCard : Card
    {
        public BlackJackCard(int c, Suit s) : base(c, s)
        {
        }

        public override int Value()
        {
            if (IsAce())
            { // Ace
                return 1;
            }
            else if (IsFaceCard())
            { // Face card
                return 10;
            }
            else
            { // Number card
                return faceValue;
            }
        }

        public int MinValue()
        {
            if (IsAce())
            { // Ace
                return 1;
            }
            else
            {
                return Value();
            }
        }

        public int MaxValue()
        {
            if (IsAce())
            { // Ace
                return 11;
            }
            else
            {
                return Value();
            }
        }

        public bool IsAce()
        {
            return faceValue == 1;
        }

        public bool IsFaceCard()
        {
            return faceValue >= 11 && faceValue <= 13;
        }
    }
}
