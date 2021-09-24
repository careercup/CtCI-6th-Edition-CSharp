using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_26_Sparse_Similarity
{
    public class Q17_26_Sparse_Similarity_Tester : Question
    {
        public static IList<int> RemoveDups(int[] array)
        {
            return array.Distinct().ToArray();
        }

        public static bool IsEqual(IDictionary<DocPair, double> one, IDictionary<DocPair, double> two)
        {
            if (one.Count != two.Count)
            {
                return false;
            }

            foreach (var a in one)
            {
                if (!two.ContainsKey(a.Key))
                {
                    return false;
                }
                double sim1 = a.Value;
                double sim2 = two[a.Key];
                if (sim1 != sim2)
                {
                    return false;
                }
            }
            return true;
        }

        public static void PrintSim(IDictionary<DocPair, double> similarities)
        {
            foreach (var result in similarities)
            {
                DocPair pair = result.Key;
                double sim = result.Value;
                Console.WriteLine(pair.Doc1 + ", " + pair.Doc2 + " : " + sim);
            }
        }

        public static void AddTo(IDictionary<int, Document> documents, int id, int[] array)
        {
            IList<int> w = RemoveDups(array);
            Document doc = new Document(id, w);
            documents.Add(id, doc);
        }

        public static string Print(IList<int> w)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            for (int c = 0; c < w.Count; c++)
            {
                sb.Append(w[c]);
                if (c != w.Count - 1) sb.Append(", ");
            }
            sb.Append(']');
            return sb.ToString();
        }


        public override void Run()
        {
            /*int numDocuments = 5;
			int docSize = 5;
			HashMap<int, Document> documents = new HashMap<int, Document>();
			for (int i = 0; i < numDocuments; i++) {
				int[] words = AssortedMethods.randomArray(docSize, 0, 10);
				IList<int> w = removeDups(words);
				Console.WriteLine(i + ": " + w.toString());
				Document doc = new Document(i, w);
				documents.put(i, doc);
			}*/
            IDictionary<int, Document> documents = new Dictionary<int, Document>();

            int[] array1 = { 14, 15, 100, 9, 3 };
            AddTo(documents, 13, array1);

            int[] array2 = { 32, 1, 9, 3, 5 };
            AddTo(documents, 16, array2);

            int[] array3 = { 15, 29, 2, 6, 8, 7 };
            AddTo(documents, 19, array3);

            int[] array4 = { 7, 10 };
            AddTo(documents, 24, array4);


            IDictionary<DocPair, double> simA = Q17_26_Sparse_SimilarityA.ComputeSimilaritiesA(documents);
            IDictionary<DocPair, double> simB = Q17_26_Sparse_SimilarityB.ComputeSimilaritiesB(documents);
            IDictionary<DocPair, double> simC = Q17_26_Sparse_SimilarityC.ComputeSimilaritiesC(documents);
            Console.WriteLine("----------");
            PrintSim(simA);
            Console.WriteLine("----------");
            PrintSim(simB);
            Console.WriteLine("----------");
            PrintSim(simC);
            Console.WriteLine("----------");

            Console.WriteLine(IsEqual(simA, simB));
            Console.WriteLine(IsEqual(simB, simC));
            Console.WriteLine(IsEqual(simA, simC));
        }
    }
}
