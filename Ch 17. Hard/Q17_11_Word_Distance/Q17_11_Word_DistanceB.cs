using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_11_Word_Distance
{
	// 執行多次
	// Hash table
	// 預先計算位置: 
	// Time complexity: O(N)
	// N: 字串中字的數量
	// 找出最近的配對位置
	// Time complexity: O(A + B)
	// A: 第一個字的出現次數
	// B: 第二個字的出現次數
	public class Q17_11_Word_DistanceB : Question
    {
		public static LocationPair FindClosestB(string word1, string word2, DictionaryList<string,int> locations)
		{
			IList<int> locations1 = locations.Get(word1);
			IList<int> locations2 = locations.Get(word2);
			return FindMinDistancePair(locations1, locations2);
		}

		public static LocationPair FindMinDistancePair(IList<int> array1, IList<int> array2)
		{
			if (array1 == null || array2 == null || array1.Count == 0 || array2.Count == 0)
			{
				return null;
			}

			int index1 = 0;
			int index2 = 0;
			LocationPair best = new LocationPair(array1[0], array2[0]);
			LocationPair current = new LocationPair(array1[0], array2[0]);

			while (index1 < array1.Count && index2 < array2.Count)
			{
				current.SetLocations(array1[index1], array2[index2]);
				best.UpdateWithMin(current);
				if (current.Location1 < current.Location2)
				{
					index1++;
				}
				else
				{
					index2++;
				}
			}

			return best;
		}

		public static DictionaryList<string,int> GetWordLocations(string[] words)
		{
			DictionaryList<string,int> locations = new DictionaryList<string,int>();
			for (int i = 0; i < words.Length; i++)
			{
				locations.Add(words[i], i);
			}
			return locations;
		}
		

		public override void Run()
        {
			string[] wordlist = AssortedMethods.GetLongTextBlobAsStringList();
			string word1 = "river";
			string word2 = "life";
			DictionaryList<string, int> locations = GetWordLocations(wordlist);
			LocationPair pair = FindClosestB(word1, word2, locations);
			Console.WriteLine("Distance between <" + word1 + "> and <" + word2 + ">: " + pair.ToString());
		}
    }
}
