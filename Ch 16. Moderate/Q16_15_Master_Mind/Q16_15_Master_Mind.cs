using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_15_Master_Mind
{
    public class Q16_15_Master_Mind : Question
    {
		public static int MAX_COLORS = 4;

		public static Result Estimate(string guess, string solution)
		{
			if (guess.Length!= solution.Length) return null;
			Result res = new Result(0, 0);
			int[] frequencies = new int[MAX_COLORS];

			/* Compute hits and built frequency table */
			for (int i = 0; i < guess.Length; i++)
			{
				if (guess[i] == solution[i])
				{
					res.Hits++;
				}
				else
				{
					/* Only increment the frequency table (which will be used for pseudo-hits) if
					 * it's not a hit. If it's a hit, the slot has already been "used." */
					int code = Code(solution[i]);
					if (code >= 0)
					{
						frequencies[code]++;
					}
				}
			}

			/* Compute pseudo-hits */
			for (int i = 0; i < guess.Length; i++)
			{
				int code = Code(guess[i]);
				if (code >= 0 && frequencies[code] > 0 && guess[i] != solution[i])
				{
					res.PseudoHits++;
					frequencies[code]--;
				}
			}

			return res;
		}


		public static int Code(char c)
		{
			switch (c)
			{
				case 'B':
					return 0;
				case 'G':
					return 1;
				case 'R':
					return 2;
				case 'Y':
					return 3;
				default:
					return -1;
			}
		}

		public static char LetterFromCode(int k)
		{
			switch (k)
			{
				case 0:
					return 'B';
				case 1:
					return 'G';
				case 2:
					return 'R';
				case 3:
					return 'Y';
				default:
					return '0';
			}
		}

		

		public override void Run()
        {
			Result res = Estimate("GGRR", "RGBY");
			Console.WriteLine(res.ToString());
		}
    }
}
