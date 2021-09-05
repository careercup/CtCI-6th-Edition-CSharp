using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_07_Permutations_Without_Dups
{
    // 從所有 n-1 字元子字串的排列組合建構
    public class Q8_07_Permutations_Without_DupsB : Question
    {
        public static IList<string> GetPerms(string remainder)
        {
            int len = remainder.Length;
            IList<string> result = new List<string>();

            /* Base case. */
            if (len == 0)
            {
                result.Add(""); // Be sure to return empty string!
                return result;
            }


            for (int i = 0; i < len; i++)
            {
                /* Remove char i and find permutations of remaining characters.*/
                string before = remainder.Substring(0, i);
                string after = remainder.Substring(i + 1);
                IList<string> partials = GetPerms(before + after);

                /* Prepend char i to each permutation.*/
                foreach (string s in partials)
                {
                    result.Add(remainder[i] + s);
                }
            }

            return result;
        }

        public override void Run()
        {
            IList<string> list = GetPerms("abc");
            Console.WriteLine("There are " + list.Count + " permutations.");
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
        }
    }
}
