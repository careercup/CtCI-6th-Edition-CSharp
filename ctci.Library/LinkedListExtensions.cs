using System.Collections.Generic;

namespace ctci.Library
{
    public static class LinkedListExtensions   
    {
        public static void AddAll<T>(this LinkedList<T> source,
                                        IEnumerable<T> items)
        { 
            if (source == null)
                throw new System.ArgumentNullException(nameof(source));
           
            if (items == null)
                throw new System.ArgumentNullException(nameof(items));
            
            foreach (T item in items)
                source.AddLast(item);
        }
    }
}