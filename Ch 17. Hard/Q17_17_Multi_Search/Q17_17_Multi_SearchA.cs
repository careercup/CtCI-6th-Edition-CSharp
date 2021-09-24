using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_17_Multi_Search
{
    // 方案1
    // Time complexity: O(kbt)
    // k: T 中(陣列中)的最長字串長度
    // b: 較大字串的長度(big)
    // t: T (陣列)的數量
    public class Q17_17_Multi_SearchA : Question
    {
        public DictionaryList<string, int> SearchAllA(string big, string[] smalls)
        {
            DictionaryList<string, int> lookup = new DictionaryList<string, int>();
            foreach (string small in smalls)
            {
                IList<int> locations = Search(big, small);
                lookup.Add(small, locations);
            }
            return lookup;
        }

        public IList<int> Search(string big, string small)
        {
            IList<int> locations = new List<int>();
            for (int i = 0; i < big.Length - small.Length + 1; i++)
            {
                if (IsSubstringAtLocation(big, small, i))
                {
                    locations.Add(i);
                }
            }
            return locations;
        }

        public bool IsSubstringAtLocation(string big, string small, int offset)
        {
            for (int i = 0; i < small.Length; i++)
            {
                if (big[offset + i] != small[i])
                {
                    return false;
                }
            }
            return true;
        }


        public override void Run()
        {
            string big = "mississippi";
            string[] smalls = { "is", "ppi", "hi", "sis", "i", "mississippi" };
            DictionaryList<string, int> locations = SearchAllA(big, smalls);
            Console.WriteLine(locations.ToString());
        }
    }
}
