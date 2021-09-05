using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_06_Towers_of_Hanoi
{
	public class Tower
	{
		private Stack<int> disks = new Stack<int>();
		public string Name { get; set; }

		public void Add(int d)
		{
			if (disks.Count>0 && disks.Peek() <= d)
			{
				Console.WriteLine("Error placing disk " + d);
			}
			else
			{
				disks.Push(d);
			}
		}

		public void MoveTopTo(Tower t)
		{
			int top = disks.Pop();
			t.Add(top);
		}

		public void Print()
		{
			Console.Write("Contents of Tower " + Name + ": ");
            foreach (var d in disks)
            {
				Console.Write($"{d}, ");
            }
			Console.WriteLine();
		}

		public void MoveDisks(int quantity, Tower destination, Tower buffer)
		{
			if (quantity <= 0) return;

			MoveDisks(quantity - 1, buffer, destination);
			Console.WriteLine("Move " + disks.Peek() + " from " + this.Name + " to " + destination.Name);
			MoveTopTo(destination);
			buffer.MoveDisks(quantity - 1, destination, this);
		}
	}
}
