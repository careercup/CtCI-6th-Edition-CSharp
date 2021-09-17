using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_03_Random_Set
{
	// 與 17.2 洗牌(Shuffle)問題相似
	public class Q17_03_Random_Set : Question
    {
		/* pick M elements from original array, using only elements 0 through i (inclusive).*/
		public static int[] PickMRecursively(int[] original, int m, int i)
		{
			if (i + 1 < m)
			{ // Not enough elements
				return null;
			}
			else if (i + 1 == m)
			{ // Base case -- copy first m elements into array
				int[] set = new int[m];
				for (int k = 0; k < m; k++)
				{
					set[k] = original[k];
				}
				return set;
			}
			else
			{
				int[] set = PickMRecursively(original, m, i - 1);
				Random rand = new Random();
				int k = rand.Next(i + 1); // Generate random between 0 and i (inclusive)
				if (k < m)
				{
					set[k] = original[i];
				}
				return set;
			}
		}

		/* pick M elements from original array.*/
		public static int[] PickMIteratively(int[] original, int m)
		{
			if (m > original.Length) return null;
			int[] subset = new int[m];

			/* Fill in subset array with first part of original array */
			for (int i = 0; i < m; i++)
			{
				subset[i] = original[i];
			}

			Random rand = new Random();

			/* Go through rest of original array. */
			for (int i = m; i < original.Length; i++)
			{
				int k = rand.Next(i + 1); // Generate random between 0 and i (inclusive)
				if (k < m)
				{
					subset[k] = original[i];
				}
			}

			return subset;
		}

		public override void Run()
        {
			int[] cards = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			Console.WriteLine(AssortedMethods.ArrayToString(cards));
			int[] set = PickMIteratively(cards, 4);
			Console.WriteLine(AssortedMethods.ArrayToString(set));
		}
    }
}
