using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_09._Scalability_and_Memory_Limits.Q9_05_Cache
{
	// 步驟1: 設計單一系統的快取
	public class Cache
	{
		public static int MAX_SIZE = 10;
		public Node Head { get; private set; }
		public Node Tail { get; private set; }
		public Dictionary<string, Node> Map { get; private set; }
		public int Size { get; private set; } = 0;

		public Cache()
		{
			Map = new Dictionary<string, Node>();
		}

		public void MoveToFront(Node node)
		{
			if (node == Head)
			{
				return;
			}
			RemoveFromLinkedList(node);
			node.Next = Head;
			if (Head != null)
			{
				Head.Prev = node;
			}
			Head = node;
			Size++;

			if (Tail == null)
			{
				Tail = node;
			}
		}

		public void MoveToFront(string query)
		{
			Node node = Map[query];
			MoveToFront(node);
		}

		public void RemoveFromLinkedList(Node node)
		{
			if (node == null)
			{
				return;
			}

			if (node.Next != null || node.Prev != null)
			{
				Size--;
			}

			Node prev = node.Prev;
			if (prev != null)
			{
				prev.Next = node.Next;
			}

			Node next = node.Next;
			if (next != null)
			{
				next.Prev = prev;
			}

			if (node == Head)
			{
				Head = next;
			}

			if (node == Tail)
			{
				Tail = prev;
			}

			node.Next = null;
			node.Prev = null;
		}

		public string[] GetResults(string query)
		{
			if (Map.ContainsKey(query))
			{
				Node node = Map[query];
				MoveToFront(node);
				return node.Results;
			}
			return null;
		}

		public void InsertResults(string query, string[] results)
		{
			if (Map.ContainsKey(query))
			{
				Node n = Map[query];
				n.Results = results;
				MoveToFront(n);
				return;
			}

			Node node = new Node(query, results);
			MoveToFront(node);
			Map[query]= node;

			if (Size > MAX_SIZE)
			{
				Map.Remove(Tail.Query);
				RemoveFromLinkedList(Tail);
			}
		}
	}
}
