using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_09._Scalability_and_Memory_Limits.Q9_05_Cache
{
    public class Q9_05_Cache : Question
    {
        public static string[] GenerateResults(int i)
        {
            string[] results = { "resultA" + i, "resultB" + i, "resultC" + i };
            return results;
        }

        public override void Run()
        {
			Cache cache = new Cache();
			for (int i = 0; i < 20; i++)
			{
				string query = "query" + i;
				cache.InsertResults(query, GenerateResults(i));
				if (i == 9 || i == 16 || i == 19)
				{
					cache.GetResults("query" + 2);
					cache.GetResults("query" + 6);
					cache.GetResults("query" + 9);
				}
			}

			for (int i = 0; i < 30; i++)
			{
				string query = "query" + i;
				string[] results = cache.GetResults(query);
				Console.Write(query + ": ");
				if (results == null)
				{
					Console.Write("null");
				}
				else
				{
					foreach (string s in results)
					{
						Console.Write(s + ", ");
					}
				}
				Console.WriteLine("");
			}
		}
    }
}
