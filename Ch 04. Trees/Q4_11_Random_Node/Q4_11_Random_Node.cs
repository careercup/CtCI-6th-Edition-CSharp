using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_04._Trees.Q4_11_Random_Node
{
    public class Q4_11_Random_Node : Question
    {
        public override void Run()
        {
			int[] counts = new int[10];
			for (int i = 0; i < 1000000; i++)
			{
				Tree tree = new Tree();
				int[] array = { 1, 0, 6, 2, 3, 9, 4, 5, 8, 7 };
				foreach (int x in array)
				{
					tree.InsertInOrder(x);
				}
				int d = tree.GetRandomNode().Data;
				counts[d]++;
			}

			for (int i = 0; i < counts.Length; i++)
			{
				Console.WriteLine(i + ": " + counts[i]);
			}
		}
    }
}
