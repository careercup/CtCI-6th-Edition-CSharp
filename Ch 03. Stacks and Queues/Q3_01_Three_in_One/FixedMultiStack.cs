using System;
using System.Collections.Generic;
using System.Text;
using Ch_03._Stacks_and_Queues.Helpers;
using ctci.Library;

namespace Ch_03._Stacks_and_Queues.Q3_01_Three_in_One
{
    public class FixedMultiStack
    {
        private int numberOfStacks = 3;
        private int stackCapacity;
        private int[] values;
        private int[] sizes;

        public FixedMultiStack(int stackSize)
        {
            stackCapacity = stackSize;
            values = new int[stackSize * numberOfStacks];
            sizes = new int[numberOfStacks];
        }

        /* Push value onto stack. */
        public void Push(int stackNum, int value)
        {
            /* Check that we have space for the next element */
            if (IsFull(stackNum))
            {
                throw new FullStackException();
            }

            /* Increment stack pointer and then update top value. */
            sizes[stackNum]++;
            values[IndexOfTop(stackNum)] = value;
        }

        /* Pop item from top stack. */
        public int Pop(int stackNum)
        {
            if (IsEmpty(stackNum))
            {
                throw new EmptyStackException();
            }

            int topIndex = IndexOfTop(stackNum);
            int value = values[topIndex]; // Get top
            values[topIndex] = 0; // Clear 
            sizes[stackNum]--; // Shrink
            return value;
        }

        /* Return top element. */
        public int Peek(int stackNum)
        {
            if (IsEmpty(stackNum))
            {
                throw new EmptyStackException();
            }
            return values[IndexOfTop(stackNum)];
        }

        /* Return if stack is empty. */
        public bool IsEmpty(int stackNum)
        {
            return sizes[stackNum] == 0;
        }

        /* Return if stack is full. */
        public bool IsFull(int stackNum)
        {
            return sizes[stackNum] == stackCapacity;
        }

        /* Returns index of the top of the stack. */
        private int IndexOfTop(int stackNum)
        {
            int offset = stackNum * stackCapacity;
            int size = sizes[stackNum];
            return offset + size - 1;
        }

        public int[] GetValues()
        {
            return values;
        }

        public int[] GetStackValues(int stackNum)
        {
            int[] items = new int[sizes[stackNum]];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = values[stackNum * stackCapacity + i];
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
