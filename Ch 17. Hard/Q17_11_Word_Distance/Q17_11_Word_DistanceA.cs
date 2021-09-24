using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_11_Word_Distance
{
	// 執行一次
    public class Q17_11_Word_DistanceA : Question
    {
		public static LocationPair findClosest(string[] words, string word1, string word2)
		{
			LocationPair best = new LocationPair(-1, -1);
			LocationPair current = new LocationPair(-1, -1);
			for (int i = 0; i < words.Length; i++)
			{
				string word = words[i];
				if (word.Equals(word1))
				{
					current.Location1 = i;
					best.UpdateWithMin(current);
				}
				else if (word.Equals(word2))
				{
					current.Location2 = i;
					best.UpdateWithMin(current);
				}
			}
			return best;
		}

		public override void Run()
        {
			string[] wordlist = AssortedMethods.GetLongTextBlobAsStringList();
			string word1 = "river";
			string word2 = "life";
			LocationPair pair = findClosest(wordlist, word1, word2);
			Console.WriteLine("Distance between <" + word1 + "> and <" + word2 + ">: " + pair.ToString());
		}
    }
}
