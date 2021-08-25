using Ch_03._Stacks_and_Queues.Helpers;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_01_Three_in_One
{
    public class MultiStack
    {
        /* StackInfo is a simple class that holds a set of data about 
		 * each stack. It does not hold the actual items in the stack. 
		 * We could have done this with just a bunch of individual 
		 * variables, but that’s messy and doesn’t gain us much. */
        private class StackInfo
        {
            public int Start { get; set; }
            public int Size { get; set; }
            public int Capacity { get; set; }
            public StackInfo(int start, int capacity)
            {
                this.Start = start;
                this.Capacity = capacity;
            }

            /* Check if an index on the full array is within the stack
			 * boundaries. The stack can wrap around to the start of 
			 * the array. */
            public bool IsWithinStackCapacity(int index)
            {
                /* If outside of bounds of array, return false. */
                if (index < 0 || index >= values.Length)
                {
                    return false;
                }

                /* If index wraps around, adjust it. */
                int contiguousIndex = index < Start ? index + values.Length : index;
                int end = Start + Capacity;
                return Start <= contiguousIndex && contiguousIndex < end;
            }

            public int LastCapacityIndex()
            {
                return AdjustIndex(Start + Capacity - 1);
            }

            public int LastElementIndex()
            {
                return AdjustIndex(Start + Size - 1);
            }

            public bool IsFull()
            {
                return Size == Capacity;
            }

            public bool IsEmpty()
            {
                return Size == 0;
            }
        }

        private StackInfo[] info;
        private static int[] values;

        public MultiStack(int numberOfStacks, int defaultSize)
        {
            /* Create metadata for all the stacks. */
            info = new StackInfo[numberOfStacks];
            for (int i = 0; i < numberOfStacks; i++)
            {
                info[i] = new StackInfo(defaultSize * i, defaultSize);
            }
            values = new int[numberOfStacks * defaultSize];
        }

        /* Returns the number of items actually present in stack. */
        public int NumberOfElements()
        {
            int size = 0;
            foreach (StackInfo sd in info)
            {
                size += sd.Size;
            }
            return size;
        }

        /* Returns true is all the stacks are full. */
        public bool AllStacksAreFull()
        {
            return NumberOfElements() == values.Length;
        }

        /* Adjust index to be within the range of 0 -> length - 1. */
        private static int AdjustIndex(int index)
        {
            /* Java's mod operator can return neg values. For example,
			 * (-11 % 5) will return -1, not 4. We actually want the 
			 * value to be 4 (since we're wrapping around the index). 
			 */
            int max = values.Length;
            return ((index % max) + max) % max;
        }

        /* Get index after this index, adjusted for wrap around. */
        private int NextIndex(int index)
        {
            return AdjustIndex(index + 1);
        }

        /* Get index before this index, adjusted for wrap around. */
        private int PreviousIndex(int index)
        {
            return AdjustIndex(index - 1);
        }

        /* Shift items in stack over by one element. If we have 
		 * available capacity, then we'll end up shrinking the stack 
		 * by one element. If we don't have available capacity, then
		 * we'll need to shift the next stack over too. */
        private void Shift(int stackNum)
        {
            Console.WriteLine("/// Shifting " + stackNum);
            StackInfo stack = info[stackNum];

            /* If this stack is at its full capacity, then you need
			 * to move the next stack over by one element. This stack
			 * can now claim the freed index. */
            if (stack.Size >= stack.Capacity)
            {
                int nextStack = (stackNum + 1) % info.Length;
                Shift(nextStack);
                stack.Capacity++; // claim index that next stack lost
            }

            /* Shift all elements in stack over by one. */
            int index = stack.LastCapacityIndex();
            while (stack.IsWithinStackCapacity(index))
            {
                values[index] = values[PreviousIndex(index)];
                index = PreviousIndex(index);
            }

            /* Adjust stack data. */
            values[stack.Start] = 0; // Clear item
            stack.Start = NextIndex(stack.Start); // move start
            stack.Capacity--; // Shrink capacity
        }

        /* Expand stack by shifting over other stacks */
        private void Expand(int stackNum)
        {
            Console.WriteLine("/// Expanding stack " + stackNum);

            Shift((stackNum + 1) % info.Length);
            info[stackNum].Capacity++;
        }

        /* Push value onto stack num, shifting/expanding stacks as 
		 * necessary. Throws exception if all stacks are full. */
        public void Push(int stackNum, int value)
        {
            Console.WriteLine("/// Pushing stack " + stackNum + ": " + value);
            if (AllStacksAreFull())
            {
                throw new FullStackException();
            }

            /* If this stack is full, expand it. */
            StackInfo stack = info[stackNum];
            if (stack.IsFull())
            {
                Expand(stackNum);
            }

            /* Find the index of the top element in the array + 1, 
             * and increment the stack pointer */
            stack.Size++;
            values[stack.LastElementIndex()] = value;
        }

        /* Remove value from stack. */
        public int Pop(int stackNum)
        {
            Console.WriteLine("/// Popping stack " + stackNum);
            StackInfo stack = info[stackNum];
            if (stack.IsEmpty())
            {
                throw new EmptyStackException();
            }

            /* Remove last element. */
            int value = values[stack.LastElementIndex()];
            values[stack.LastElementIndex()] = 0; // Clear item
            stack.Size--; // Shrink size
            return value;
        }

        /* Get top element of stack.*/
        public int Peek(int stackNum)
        {
            StackInfo stack = info[stackNum];
            return values[stack.LastElementIndex()];
        }

        public int[] GetValues()
        {
            return values;
        }

        public int[] GetStackValues(int stackNum)
        {
            StackInfo stack = info[stackNum];
            int[] items = new int[stack.Size];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = values[AdjustIndex(stack.Start + i)];
            }
            return items;
        }

        public string StackToString(int stackNum)
        {
            int[] items = GetStackValues(stackNum);
            return stackNum + ": " + AssortedMethods.ArrayToString(items);
        }
    }
}
