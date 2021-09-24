using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_18_Shortest_Supersequence
{
	/* CountedLookup acts a simple hash table with increment/decrement functions
	 * which can efficiently tell you how many values in the hash table are
	 * at least one. 
	 */
	public class CountedLookup
	{
		IDictionary<int, int> lookup = new Dictionary<int, int>();
		int fulfilled = 0;
		public CountedLookup(int[] array)
		{
			foreach (int a in array)
			{
				lookup.Add(a, 0);
			}
		}

		public bool Contains(int v)
		{
			return lookup.ContainsKey(v);
		}

		public void IncrementIfFound(int v)
		{
			if (!Contains(v)) return;
			int value = lookup.ContainsKey(v) ? lookup[v] : 0;
			if (value == 0)
			{
				fulfilled += 1;
			}
			lookup[v]++;
		}

		public void DecrementIfFound(int v)
		{
			if (!Contains(v)) return;
			lookup[v]--;
			if (lookup[v] == 0)
			{
				fulfilled -= 1;
			}
		}

		public bool AreAllFulfilled()
		{
			return fulfilled == lookup.Keys.Count;
		}
	}
}
