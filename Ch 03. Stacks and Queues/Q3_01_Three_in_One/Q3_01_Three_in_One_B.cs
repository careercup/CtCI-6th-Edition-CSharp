using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_01_Three_in_One
{
    public class Q3_01_Three_in_One_B:Question
    {
		public void PrintStacks(MultiStack stacks)
		{
			// Console.WriteLine(stacks.stackToString(0));
			// Console.WriteLine(stacks.stackToString(1));
			// Console.WriteLine(stacks.stackToString(2));
			Console.WriteLine(AssortedMethods.ArrayToString(stacks.GetValues()));
		}

        public override void Run()
        {
			MultiStack stacks = new MultiStack(3, 4);
			PrintStacks(stacks);
			stacks.Push(0, 10);
			PrintStacks(stacks);
			stacks.Push(1, 20);
			PrintStacks(stacks);
			stacks.Push(2, 30);
			PrintStacks(stacks);

			stacks.Push(1, 21);
			PrintStacks(stacks);
			stacks.Push(0, 11);
			PrintStacks(stacks);
			stacks.Push(0, 12);
			PrintStacks(stacks);

			stacks.Pop(0);
			PrintStacks(stacks);

			stacks.Push(2, 31);
			PrintStacks(stacks);

			stacks.Push(0, 13);
			PrintStacks(stacks);
			stacks.Push(1, 22);
			PrintStacks(stacks);

			stacks.Push(2, 31);
			PrintStacks(stacks);
			stacks.Push(2, 32);
			PrintStacks(stacks);
			stacks.Push(2, 33);
			PrintStacks(stacks);
			stacks.Push(2, 34);
			PrintStacks(stacks);

			stacks.Pop(1);
			PrintStacks(stacks);
			stacks.Push(2, 35);
			PrintStacks(stacks);

			Console.WriteLine("Final Stack: " + AssortedMethods.ArrayToString(stacks.GetValues()));
		}
    }
}
