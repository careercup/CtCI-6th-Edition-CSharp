using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_01_Three_in_One
{
    public class Q3_01_Three_in_One_A : Question
    {
        public void PrintStacks(FixedMultiStack stacks)
        {
            Console.WriteLine(AssortedMethods.ArrayToString(stacks.GetValues()));
        }

        public override void Run()
        {
			FixedMultiStack stacks = new FixedMultiStack(4);
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
		}
    }
}
