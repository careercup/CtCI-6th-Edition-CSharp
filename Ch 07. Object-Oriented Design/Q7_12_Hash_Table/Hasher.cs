using System;
using System.Collections.Generic;

namespace Chapter07
{ 
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
                string data = $"({Key},{Value})";
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

        private List<LinkedListNode<K, V>> _arr;
        public Hasher(int capacity)
        {
            /* Create list of linked lists. */
            _arr = new List<LinkedListNode<K, V>>();
            for (int i = 0; i < capacity; i++)
            {
                _arr.Add(null);
            }
        }

        /* Insert key and value into hash table. */
        public V Put(K key, V value)
        {
            LinkedListNode<K, V> node = GetNodeForKey(key);
            if (node != null)
            {
                V oldValue = node.Value;
                node.Value = value; // just update the value.
                return oldValue;
            }

            node = new LinkedListNode<K, V>(key, value);
            int index = GetIndexForKey(key);
            if (_arr[index] != null)
            {
                node.Next = _arr[index];
                node.Next.Prev = node;
            }
            _arr[index] = node;
            return default(V);
        }

        /* Remove node for key. */
        public V Remove(K key)
        {
            LinkedListNode<K, V> node = GetNodeForKey(key);
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
                _arr[hashKey] = node.Next;
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
            LinkedListNode<K, V> node = GetNodeForKey(key);
            return node == null ? default(V) : node.Value;
        }

        /* Get linked list node associated with a given key. */
        private LinkedListNode<K, V> GetNodeForKey(K key)
        {
            int index = GetIndexForKey(key);
            LinkedListNode<K, V> current = _arr[index];
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
            return Math.Abs(key.GetHashCode() % _arr.Count);
        }

        public void PrintTable()
        {
            for (int i = 0; i < _arr.Count; i++)
            {
                string s = _arr[i] == null ? string.Empty : _arr[i].PrintForward();
                Console.WriteLine($"{i}: {s}");
            }
        }
    }
}
