using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter05.Q5_03_Flip_Bit_to_Win
{
	// 暴力解
	// Time complexity: O(b)
	// Space complexity: O(b)
	// b: 序列長度
	public class Q5_03_Flip_Bit_to_Win_B : Question
    {
		public static int LongestSequenceB(int n)
		{
			if (n == -1) return 32; // Integer.BYTES * 8
			IList<int> sequences = GetAlternatingSequences(n);
			return FindLongestSequence(sequences);
		}

		/* Return a list of the sizes of the sequences. The sequence starts 
		 * off with the number of 0s (which might be 0) and then alternates
		 * with the counts of each value.*/
		public static IList<int> GetAlternatingSequences(int n)
		{
			IList<int> sequences = new List<int>();

			int searchingFor = 0;
			int counter = 0;

			for (int i = 0; i < 32; i++)
			{
				if ((n & 1) != searchingFor)
				{
					sequences.Add(counter);
					searchingFor = n & 1; // Flip 1 to 0 or 0 to 1
					counter = 0;
				}
				counter++;
				n >>= 1;
			}
			sequences.Add(counter);

			return sequences;
		}

		public static int FindLongestSequence(IList<int> seq)
		{
			int maxSeq = 1;

			for (int i = 0; i < seq.Count; i += 2)
			{
				int zerosSeq = seq[i];
				int onesSeqPrev = i - 1 >= 0 ? seq[i - 1] : 0;
				int onesSeqNext = i + 1 < seq.Count ? seq[i + 1] : 0;

				int thisSeq = 0;
				if (zerosSeq == 1)
				{ // Can merge
					thisSeq = onesSeqNext + 1 + onesSeqPrev;
				}
				else if (zerosSeq > 1)
				{ // Just add a one to either side
					thisSeq = 1 + Math.Max(onesSeqPrev, onesSeqNext);
				}
				else if (zerosSeq == 0)
				{ // No zero, but take either side
					thisSeq = Math.Max(onesSeqPrev, onesSeqNext);
				}
				maxSeq = Math.Max(thisSeq, maxSeq);
			}

			return maxSeq;
		}

		public override void Run()
        {
			int originalNumber = 1775;
			int newNumber = LongestSequenceB(originalNumber);

			Console.WriteLine(Convert.ToString(originalNumber, 2));
			Console.WriteLine(newNumber);
		}
    }
}
