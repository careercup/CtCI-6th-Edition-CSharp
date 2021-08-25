using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_02_Stack_Min
{
    public class Q3_02_Stack_Min : Question
    {
        public override void Run()
        {
			StackWithMinA stack = new StackWithMinA();
			StackWithMinB stack2 = new StackWithMinB();
			int[] array = { 2, 1, 3, 1 };
			foreach (int value in array)
			{
				stack.Push(value);
				stack2.Push(value);
				Console.Write(value + ", ");
			}
			Console.WriteLine('\n');
			for (int i = 0; i < array.Length; i++)
			{
				Console.WriteLine("Popped " + stack.Pop().Value + ", " + stack2.Pop());
				Console.WriteLine("New min is " + stack.Min() + ", " + stack2.Min());
			}
		}
    }
}
