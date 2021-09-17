using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ctci.Library
{
	public class DictionaryList<T, E>
	{
		private Dictionary<T, IList<E>> map = new Dictionary<T, IList<E>>();

		/* Insert item into list at key. */
		public void Add(T key, E item)
		{
			if (!map.ContainsKey(key))
			{
				map[key] = new List<E>();
			}
			map[key].Add(item);
		}

		/* Insert list of items at key. */
		public void Add(T key, IList<E> items)
		{
			map[key] = items;
		}

		/* Get list of items at key. */
		public IList<E> Get(T key)
		{
			return map.ContainsKey(key) ? map[key] : null;
		}

		/* Check if hashmaplist contains key. */
		public bool ContainsKey(T key)
		{
			return map.ContainsKey(key);
		}

		/* Check if list at key contains value. */
		public bool ContainsKeyValue(T key, E value)
		{
			IList<E> list = Get(key);
			if (list == null) return false;
			return list.Contains(value);
		}

		/* Get the list of keys. */
		public Dictionary<T, IList<E>>.KeyCollection KeySet()
		{
			return map.Keys;
		}

		public override string ToString()
		{
			StringBuilder ans = new StringBuilder();
            foreach (var pair in map)
            {
				ans.Append($"key = {pair.Key}{Environment.NewLine}");
				ans.Append($"value = (");
				for (int i = 0; i < pair.Value.Count; i++)
                {
					ans.Append(pair.Value[i]);
					if (i != pair.Value.Count - 1)
						ans.Append(", ");
					else ans.Append($"){Environment.NewLine}");
                }
            }
			return ans.ToString();
		}
	}
}
