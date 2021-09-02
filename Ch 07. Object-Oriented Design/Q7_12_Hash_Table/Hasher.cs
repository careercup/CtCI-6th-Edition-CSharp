using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_12_Hash_Table
{
	// 跑起來怪怪的
	public class Hasher<K, V>
	{
		private class LinkedListNode<K, V>
		{
			public LinkedListNode<K, V> Next { get; set; }
			public LinkedListNode<K, V> Prev { get; set; }
			public K Key { get; set; }
			public V Value { get; set; }
			public LinkedListNode(K k, V v)
			{
				Key = k;
				Value = v;
			}

			public string PrintForward()
			{
				string data = "(" + Key + "," + Value + ")";
				if (Next != null)
				{
					return data + "->" + Next.PrintForward();
				}
				else
				{
					return data;
				}
			}
		}

		private IList<LinkedListNode<K, V>> arr;
		public Hasher(int capacity)
		{
			/* Create list of linked lists. */
			arr = new List<LinkedListNode<K, V>>(capacity);
			for (int i = 0; i < capacity; i++)
			{
				arr.Add(null);
			}
		}

		/* Insert key and value into hash table. */
		public V Put(K key, V value)
		{
			LinkedListNode<K, V> node = getNodeForKey(key);
			if (node != null)
			{
				V oldValue = node.Value;
				node.Value = value; // just update the value.
				return oldValue;
			}

			node = new LinkedListNode<K, V>(key, value);
			int index = GetIndexForKey(key);
			if (arr[index]!=null)
			{
				node.Next = arr[index];
				node.Next.Prev = node;
			}
			arr.Add(node);
			return default(V);
		}

		/* Remove node for key. */
		public V Remove(K key)
		{
			LinkedListNode<K, V> node = getNodeForKey(key);
			if (node == null)
			{
				return default(V);
			}

			if (node.Prev != null)
			{
				node.Prev.Next = node.Next;
			}
			else
			{
				/* Removing head - update. */
				int hashKey = GetIndexForKey(key);
				arr[hashKey] = node.Next;
			}

			if (node.Next != null)
			{
				node.Next.Prev = node.Prev;
			}
			return node.Value;
		}

		/* Get value for key. */
		public V Get(K key)
		{
			if (key == null) return default(V);
			LinkedListNode<K, V> node = getNodeForKey(key);
			return node == null ? default(V) : node.Value;
		}

		/* Get linked list node associated with a given key. */
		private LinkedListNode<K, V> getNodeForKey(K key)
		{
			int index = GetIndexForKey(key);
			LinkedListNode<K, V> current = arr[index];
			while (current != null)
			{
				if (current.Key.Equals(key))
				{
					return current;
				}
				current = current.Next;
			}
			return null;
		}

		/* Really stupid function to map a key to an index. */
		public int GetIndexForKey(K key)
		{
			return Math.Abs(key.GetHashCode() % arr.Count);
		}

		public void PrintTable()
		{
			for (int i = 0; i < arr.Count; i++)
			{
				string s = arr[i] == null ? "" : arr[i].PrintForward();
				Console.WriteLine(i + ": " + s);
			}
		}
	}
}
