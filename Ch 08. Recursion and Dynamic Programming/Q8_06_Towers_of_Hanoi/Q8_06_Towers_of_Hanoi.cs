using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_06_Towers_of_Hanoi
{
    public class Q8_06_Towers_of_Hanoi : Question
    {
        public override void Run()
        {
			Tower source = new Tower();
			Tower destination = new Tower();
			Tower buffer = new Tower();

			source.Name = "s";
			destination.Name = "d";
			buffer.Name = "b";

			/* Load up tower */
			int numberOfDisks = 5;
			for (int disk = numberOfDisks - 1; disk >= 0; disk--)
			{
				source.Add(disk);
			}

			source.Print();
			source.MoveDisks(numberOfDisks, destination, buffer);
			destination.Print();
		}
    }
}
