using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_26_Sparse_Similarity
{
	public class Document
	{
		private IList<int> words;
		private int docId;

		public Document(int id, IList<int> w)
		{
			docId = id;
			words = w;
		}

		public IList<int> GetWords()
		{
			return words;
		}

		public int GetId()
		{
			return docId;
		}

		public int Size()
		{
			return words == null ? 0 : words.Count;
		}
	}
}
