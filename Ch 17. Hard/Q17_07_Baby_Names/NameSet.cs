using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_07_Baby_Names
{
	public class NameSet
	{
		private HashSet<string> names = new HashSet<string>();
		private int frequency = 0;
		private string rootName;

		public NameSet(string name, int freq)
		{
			names.Add(name);
			frequency = freq;
			rootName = name;
		}

		public HashSet<string> GetNames()
		{
			return names;
		}

		public string GetRootName()
		{
			return rootName;
		}

		public void CopyNamesWithFrequency(HashSet<string> more, int freq)
		{
            foreach (var name in more)
            {
				names.Add(name);
            }
			frequency += freq;
		}

		public int GetFrequency()
		{
			return frequency;
		}

		public int Size()
		{
			return names.Count;
		}
	}
}
