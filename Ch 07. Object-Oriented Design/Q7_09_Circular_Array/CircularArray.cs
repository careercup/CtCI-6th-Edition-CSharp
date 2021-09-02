using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_09_Circular_Array
{
    // 實作不確定是否正確
    // Iterable => IEnumerable
    public class CircularArray<T> : IEnumerable<T>
    {
        private static T[] items;
        private static int head = 0;

        public CircularArray(int size)
        {
            items = (T[])new T[size];
        }

        private static int Convert(int index)
        {
            if (index < 0)
            {
                index += items.Length;
            }
            return (head + index) % items.Length;
        }

        public void Rotate(int shiftRight)
        {
            head = Convert(shiftRight);
        }

        public T Get(int i)
        {
            if (i < 0 || i >= items.Length)
            {
                throw new IndexOutOfRangeException("Index " + i + " is out of bounds");
            }
            return items[Convert(i)];
        }

        public void Set(int i, T item)
        {
            items[Convert(i)] = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CircularArrayIEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        // Iterator => IEnumerator
        private class CircularArrayIEnumerator : IEnumerator<T>
        {
            private int _current = -1;

            public CircularArrayIEnumerator() { }

            public T Current { get { return Next(); } }

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                return;
            }


            public bool MoveNext()
            {
                return _current < items.Length - 1;
            }

            public T Next()
            {
                _current++;
                return (T)items[Convert(_current)];
            }

            public void Remove()
            {
                throw new InvalidOperationException("Remove is not supported by CircularArray");
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
