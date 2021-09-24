using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_26_Sparse_Similarity
{
	// 最佳化(另一種做法)
	// Solution B 的演算法慢一些(由於排序)，但都比 Solution A 的演算法快。
    public class Q17_26_Sparse_SimilarityC : Question
    {
		public static IDictionary<DocPair, double> ComputeSimilaritiesC(IDictionary<int, Document> documents)
		{
			IList<Element> elements = SortWords(documents);
			IDictionary<DocPair, double> similarities = ComputeIntersections(elements);
			AdjustToSimilarities(documents, similarities);
			return similarities;
		}

		/* Throw all words into one list, sorting by the word then the document. */
		public static IList<Element> SortWords(IDictionary<int, Document> docs)
		{
			IList<Element> elements = new List<Element>();
			foreach (Document doc in docs.Values)
			{
				IList<int> words = doc.GetWords();
				foreach (int word in words)
				{
					elements.Add(new Element(word, doc.GetId()));
				}
			}
			((List<Element>)elements).Sort();
			return elements;
		}

		/* Adjust the intersection value to become the similarity. */
		public static IDictionary<DocPair, double> ComputeIntersections(IList<Element> elements)
		{
			IDictionary<DocPair, double> similarities = new Dictionary<DocPair, double>();

			for (int i = 0; i < elements.Count; i++)
			{
				Element left = elements[i];
				for (int j = i + 1; j < elements.Count; j++)
				{
					Element right = elements[j];
					if (left.Word != right.Word)
					{
						break;
					}
					Increment(similarities, left.Document, right.Document);
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
				similarities[pair] = intersection / union;
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

            IDictionary<DocPair, double> similarities = ComputeSimilaritiesC(documents);
            Q17_26_Sparse_Similarity_Tester.PrintSim(similarities);
        }
    }
}
