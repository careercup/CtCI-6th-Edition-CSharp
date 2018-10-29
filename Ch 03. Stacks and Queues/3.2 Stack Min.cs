using ctci.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._2_Stack_Min
{
    class Q3_02_StackMin : Question
    {
        public override void Run()
        {
            //LD create and populate a stack
            StackOverride aStack = new StackOverride();

            aStack.Push(6);
            aStack.Push(9);
            aStack.Push(3);
            aStack.Push(12);
            Console.WriteLine("Min expected 3 -> " + aStack.getCurrentMin());
            aStack.Pop();
            aStack.Pop();
            Console.WriteLine("Min expected 6 -> " + aStack.getCurrentMin());
            aStack.Push(4);
            Console.WriteLine("Min expected 4 -> " + aStack.getCurrentMin());
            aStack.Push(4);
            aStack.Push(44);
            Console.WriteLine("Min expected 4 -> " + aStack.getCurrentMin());

            Console.ReadLine();
        }

        #region Support Class
        // Override Stack class, add additional "supportStack" to keep track of mins.
        // push in supportStack new min when pushing value in main stack <= supportStack current min
        // pop from support stack when popping value from main stack equal current supportStack min

        public class StackOverride : Stack
        {
            Stack<int> supportStack;

            public StackOverride() : base()
            {
                //LD adding a support stack
                supportStack = new Stack<int>();
            }

            public int getCurrentMin()
            {
                if (supportStack.Count() == 0)
                {
                    return int.MaxValue;
                }
                else
                {
                    return supportStack.Peek();
                }
            }

            // redefine "Push"
            public void Push(int value)
            {
                if (value <= getCurrentMin())
                {
                    supportStack.Push(value);
                }

                base.Push(value);
            }

            // redefine "Pop"
            public int Pop()
            {
                int value = (int)base.Pop();
                if (value == getCurrentMin())
                {
                    supportStack.Pop();
                }

                return value;
            }
        }

        #endregion Support Class End

    }//class
}//namespace
