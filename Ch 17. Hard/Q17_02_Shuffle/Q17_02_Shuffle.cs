using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_02_Shuffle
{
    public class Q17_02_Shuffle : Question
    {
		public int[] ShuffleArrayRecursively(int[] cards, int i)
		{
			if (i == 0)
			{
				return cards;
			}

			/* shuffle elements 0 through index - 1 */
			ShuffleArrayRecursively(cards, i - 1);
			Random rand = new Random();
			int k = rand.Next(i + 1); // Generate random between 0 and i (inclusive)		

			/* Swap element k and index */
			int temp = cards[k];
			cards[k] = cards[i];
			cards[i] = temp;

			/* Return shuffled array */
			return cards;
		}

		public static void ShuffleArrayIteratively(int[] cards)
		{
			Random rand = new Random();
			for (int i = 0; i < cards.Length; i++)
			{
				int k = rand.Next(i + 1); // Generate random between 0 and i (inclusive)
				int temp = cards[k];
				cards[k] = cards[i];
				cards[i] = temp;
			}
		}

		public override void Run()
        {
			int[] cards = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			Console.WriteLine(AssortedMethods.ArrayToString(cards));
			ShuffleArrayIteratively(cards);
			Console.WriteLine(AssortedMethods.ArrayToString(cards));
		}
    }
}
