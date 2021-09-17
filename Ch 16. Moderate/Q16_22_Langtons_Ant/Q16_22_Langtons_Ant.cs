using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_22_Langtons_Ant
{
    public class Q16_22_Langtons_Ant : Question
    {
        public override void Run()
        {
			// 方案2: 可調整大小的矩陣
			Board board = new Board();
			// 方案3: HashSet
			Grid grid = new Grid();
			Console.WriteLine(board.ToString());
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("\n\n---- MOVE " + i + " ----");
				board.Move();
				string bs = board.ToString();
				Console.WriteLine(bs);

				grid.Move();
				string gs = grid.ToString();
				Console.WriteLine(gs);

				bool equals = bs.Equals(gs);
				Console.WriteLine(equals);

				if (!equals)
				{
					break;
				}
			}
		}
    }
}
