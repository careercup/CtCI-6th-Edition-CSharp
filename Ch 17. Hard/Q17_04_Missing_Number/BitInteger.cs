using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_04_Missing_Number
{
	public class BitInteger
	{
		public static int INTEGER_SIZE;
		private bool[] bits;
		public BitInteger()
		{
			bits = new bool[INTEGER_SIZE];
		}
		/* Creates a number equal to given value. Takes time proportional 
		 * to INTEGER_SIZE. */
		public BitInteger(int value)
		{
			bits = new bool[INTEGER_SIZE];
			for (int j = 0; j < INTEGER_SIZE; j++)
			{
				if (((value >> j) & 1) == 1) bits[INTEGER_SIZE - 1 - j] = true;
				else bits[INTEGER_SIZE - 1 - j] = false;
			}
		}

		/** Returns k-th most-significant bit. */
		public int Fetch(int k)
		{
			if (bits[k]) return 1;
			else return 0;
		}

		/** Sets k-th most-significant bit. */
		public void Set(int k, int bitValue)
		{
			if (bitValue == 0) bits[k] = false;
			else bits[k] = true;
		}

		/** Sets k-th most-significant bit. */
		public void Set(int k, char bitValue)
		{
			if (bitValue == '0') bits[k] = false;
			else bits[k] = true;
		}

		/** Sets k-th most-significant bit. */
		public void Set(int k, bool bitValue)
		{
			bits[k] = bitValue;
		}

		public void SwapValues(BitInteger number)
		{
			for (int i = 0; i < INTEGER_SIZE; i++)
			{
				int temp = number.Fetch(i);
				number.Set(i, this.Fetch(i));
				this.Set(i, temp);
			}
		}

		public int ToInt()
		{
			int number = 0;
			for (int j = INTEGER_SIZE - 1; j >= 0; j--)
			{
				number = number | Fetch(j);
				if (j > 0)
				{
					number = number << 1;
				}
			}
			return number;
		}
	}
}
