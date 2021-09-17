using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_25_LRU_Cache
{
	public class Cache
	{
		private int maxCacheSize;
		private IDictionary<int, LinkedListNode> map = new Dictionary<int, LinkedListNode>();
		private LinkedListNode listHead = null;
		public LinkedListNode ListTail { get; private set; } = null;


		public Cache(int maxSize)
		{
			maxCacheSize = maxSize;
		}

		/* Get value for key and mark as most recently used. */
		public string GetValue(int key)
		{
			LinkedListNode item = map.ContainsKey(key) ? map[key] : null;
			if (item == null)
			{
				return null;
			}

			/* Move to front of list to mark as most recently used. */
			if (item != listHead)
			{
				RemoveFromLinkedList(item);
				InsertAtFrontOfLinkedList(item);
			}
			return item.Value;
		}

		/* Remove node from linked list. */
		private void RemoveFromLinkedList(LinkedListNode node)
		{
			if (node == null)
			{
				return;
			}
			if (node.Prev != null)
			{
				node.Prev.Next = node.Next;
			}
			if (node.Next != null)
			{
				node.Next.Prev = node.Prev;
			}
			if (node == ListTail)
			{
				ListTail = node.Prev;
			}
			if (node == listHead)
			{
				listHead = node.Next;
			}
		}

		/* Insert node at front of linked list. */
		private void InsertAtFrontOfLinkedList(LinkedListNode node)
		{
			if (listHead == null)
			{
				listHead = node;
				ListTail = node;
			}
			else
			{
				listHead.Prev = node;
				node.Next = listHead;
				listHead = node;
				listHead.Prev = null;
			}
		}

		/* Remove key, value pair from cache, deleting from hash table
		 * and linked list. */
		public bool RemoveKey(int key)
		{
			LinkedListNode node = map.ContainsKey(key) ? map[key] : null;
			RemoveFromLinkedList(node);
			map.Remove(key);
			return true;
		}

		/* Put key, value pair in cache. Removes old value for key if
		 * necessary. Inserts pair into linked list and hash table.*/
		public void SetKeyValue(int key, string value)
		{
			/* Remove if already there. */
			RemoveKey(key);

			/* If full, remove least recently used item from cache. */
			if (map.Count >= maxCacheSize && ListTail != null)
			{
				RemoveKey(ListTail.Key);
			}

			/* Insert new node. */
			LinkedListNode node = new LinkedListNode(key, value);
			InsertAtFrontOfLinkedList(node);
			map[key]=node;
		}

		public string GetCacheAsString()
		{
			if (listHead == null) return "";
			return listHead.PrintForward();
		}

	}
}
