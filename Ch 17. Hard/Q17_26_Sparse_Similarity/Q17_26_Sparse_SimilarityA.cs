using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_26_Sparse_Similarity
{
	// 比暴力解稍好一點
	// Total
	// Time complexity: O((D^2)W) ?
	// W: 每個文件的最多字數
	// D: 配對文件數量
	// 尋找交集、聯集:
	// Time complexity: O(A + B)
	// A、B: 兩陣列的大小
	public class Q17_26_Sparse_SimilarityA : Question
    {
		public static IDictionary<DocPair, double> ComputeSimilaritiesA(IDictionary<int, Document> documents)
		{
			IList<Document> docs = new List<Document>(documents.Values);
			return ComputeSimilarities(docs);
		}

		public static IDictionary<DocPair, double> ComputeSimilarities(IList<Document> documents)
		{
			IDictionary<DocPair, double> similarities = new Dictionary<DocPair, double>();
			for (int i = 0; i < documents.Count; i++)
			{
				for (int j = i + 1; j < documents.Count; j++)
				{
					Document doc1 = documents[i];
					Document doc2 = documents[j];
					double sim = ComputeSimilarity(doc1, doc2);
					if (sim > 0)
					{
						DocPair pair = new DocPair(doc1.GetId(), doc2.GetId());
						similarities.Add(pair, sim);
					}
				}
			}
			return similarities;
		}

		public static double ComputeSimilarity(Document doc1, Document doc2)
		{
			int intersection = 0;
			HashSet<int> set1 = new HashSet<int>(doc1.GetWords());

			foreach (int word in doc2.GetWords())
			{
				if (set1.Contains(word))
				{
					intersection++;
				}
			}

			double union = doc1.Size() + doc2.Size() - intersection;

			return intersection / union;
		}

		public override void Run()
        {
			int numDocuments = 10;
			int docSize = 5;
			IDictionary<int, Document> documents = new Dictionary<int, Document>();
			for (int i = 0; i < numDocuments; i++)
			{
				int[] words = AssortedMethods.RandomArray(docSize, 0, 10);
				IList<int>w = Q17_26_Sparse_Similarity_Tester.RemoveDups(words);

				Console.WriteLine($"{i} : {Q17_26_Sparse_Similarity_Tester.Print(w)}");
                
				Document doc = new Document(i, w);
				documents.Add(i, doc);
			}

			IDictionary<DocPair, double> similarities = ComputeSimilaritiesA(documents);
			Q17_26_Sparse_Similarity_Tester.PrintSim(similarities);
		}
    }
}
