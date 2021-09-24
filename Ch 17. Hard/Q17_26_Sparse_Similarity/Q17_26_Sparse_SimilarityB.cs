using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_26_Sparse_Similarity
{
	// 最佳化(更好的)
	// Time complexity: O(PW + DW) ?
	// W: 每個文件的最多字數
	// D: 配對文件數量
	// P: 配對個數
	public class Q17_26_Sparse_SimilarityB : Question
    {
		public static IDictionary<DocPair, double> ComputeSimilaritiesB(IDictionary<int, Document> documents)
		{
			DictionaryList<int, int> wordToDocs = GroupWords(documents);
			IDictionary<DocPair, double> similarities = ComputeIntersections(wordToDocs);
			AdjustToSimilarities(documents, similarities);
			return similarities;
		}

		/* Create hash table from each word to where it appears. */
		public static DictionaryList<int, int> GroupWords(IDictionary<int, Document> documents)
		{
			DictionaryList<int, int> wordToDocs = new DictionaryList<int, int>();

			foreach (Document doc in documents.Values)
			{
				IList<int> words = doc.GetWords();
				foreach (int word in words)
				{
					wordToDocs.Add(word, doc.GetId());
				}
			}

			return wordToDocs;
		}

		/* Compute intersections of documents. Iterate through each list of 
		 * documents and then each pair within that list, incrementing the 
		 * intersection of each page. */
		public static IDictionary<DocPair, double> ComputeIntersections(DictionaryList<int, int> wordToDocs)
		{
			IDictionary<DocPair, double> similarities = new Dictionary<DocPair, double>();
			foreach (int word in wordToDocs.KeySet())
			{
				IList<int> docs = wordToDocs.Get(word);
				((List<int>)docs).Sort();

				for (int i = 0; i < docs.Count; i++)
				{
					for (int j = i + 1; j < docs.Count; j++)
					{
						Increment(similarities, docs[i], docs[j]);
					}
				}
			}

			return similarities;
		}

		/* Increment the intersection size of each document pair. */
		public static void Increment(IDictionary<DocPair, double> similarities, int doc1, int doc2)
		{
			DocPair pair = new DocPair(doc1, doc2);
			if (!similarities.ContainsKey(pair))
			{
				similarities.Add(pair, 1.0);
			}
			else
			{
				similarities[pair]++;
			}
		}

		/* Adjust the intersection value to become the similarity. */
		public static void AdjustToSimilarities(IDictionary<int, Document> documents, IDictionary<DocPair, double> similarities)
		{
			foreach (var entry in similarities)
			{
				DocPair pair = entry.Key;
				double intersection = entry.Value;
				Document doc1 = documents[pair.Doc1];
				Document doc2 = documents[pair.Doc2];
				double union = (double)doc1.Size() + doc2.Size() - intersection;
				similarities[pair]= intersection / union;
			}
		}

		public override void Run()
        {
			int numDocuments = 10;
			int docSize = 5;
			IDictionary<int, Document> documents = new Dictionary<int, Document>();
			for (int i = 0; i < numDocuments; i++)
			{
				int[] words = AssortedMethods.RandomArray(docSize, 0, 10);
				IList<int> w = Q17_26_Sparse_Similarity_Tester.RemoveDups(words);

				Console.WriteLine($"{i} : {Q17_26_Sparse_Similarity_Tester.Print(w)}");

				Document doc = new Document(i, w);
				documents.Add(i, doc);
			}

			IDictionary<DocPair, double> similarities = ComputeSimilaritiesB(documents);
			Q17_26_Sparse_Similarity_Tester.PrintSim(similarities);
		}
    }
}
