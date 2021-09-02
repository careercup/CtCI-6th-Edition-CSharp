using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_01_Deck_of_Cards
{
    public class Suit
    {
		private int value;
		private Suit(int v)
		{
			value = v;
		}

		private Suit(SuitEnum v)
		{
			value = (int)v;
		}

		public int GetValue()
		{
			return value;
		}

		public static Suit GetSuitFromValue(int value)
		{
			switch (value)
			{
				case 0:
					return new Suit(SuitEnum.Club);
				case 1:
					return new Suit(SuitEnum.Diamond);
				case 2:
					return new Suit(SuitEnum.Heart);
				case 3:
					return new Suit(SuitEnum.Heart);
				default:
					return new Suit(SuitEnum.NonExist);
			}
		}
	}
}
