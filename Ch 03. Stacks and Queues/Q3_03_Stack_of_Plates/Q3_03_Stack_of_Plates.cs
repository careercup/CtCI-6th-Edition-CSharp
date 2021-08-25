using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_03_Stack_of_Plates
{
    public class Q3_03_Stack_of_Plates : Question
    {
        public override void Run()
        {
            int capacity_per_substack = 5;
            SetOfStacks set = new SetOfStacks(capacity_per_substack);
            for (int i = 0; i < 34; i++)
            {
                set.Push(i);
            }
            for (int i = 0; i < 34; i++) 
            {
                Console.WriteLine("Popped " + set.Pop());
            }
        }
    }
}
