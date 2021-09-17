using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_25_LRU_Cache
{
    public class Q16_25_LRU_Cache : Question
    {
        public override void Run()
        {
			int cache_size = 5;
			Cache cache = new Cache(cache_size);

			cache.SetKeyValue(1, "1");
			Console.WriteLine(cache.GetCacheAsString());
			cache.SetKeyValue(2, "2");
			Console.WriteLine(cache.GetCacheAsString());
			cache.SetKeyValue(3, "3");
			Console.WriteLine(cache.GetCacheAsString());
			cache.GetValue(1);
			Console.WriteLine(cache.GetCacheAsString());
			cache.SetKeyValue(4, "4");
			Console.WriteLine(cache.GetCacheAsString());
			cache.GetValue(2);
			Console.WriteLine(cache.GetCacheAsString());
			cache.SetKeyValue(5, "5");
			Console.WriteLine(cache.GetCacheAsString());
			cache.GetValue(5);
			Console.WriteLine(cache.GetCacheAsString());
			cache.SetKeyValue(6, "6");
			Console.WriteLine(cache.GetCacheAsString());
			cache.GetValue(1);
			Console.WriteLine(cache.GetCacheAsString());
			cache.SetKeyValue(5, "5a");
			Console.WriteLine(cache.GetCacheAsString());
			cache.GetValue(3);
			Console.WriteLine(cache.GetCacheAsString());		
		}
	}
}
