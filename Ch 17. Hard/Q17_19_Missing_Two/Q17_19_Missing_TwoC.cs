using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_17._Hard.Q17_19_Missing_Two
{
	// 第二部份: 找出兩個少掉的數字
	public class Q17_19_Missing_TwoC : Question
    {
		public static int[] MissingTwoC(int[] array)
		{
			int max_value = array.Length + 2;
			int rem_square = SquareSumToN(max_value, 2);
			int rem_one = max_value * (max_value + 1) / 2;

			for (int i = 0; i < array.Length; i++)
			{
				rem_square -= array[i] * array[i];
				rem_one -= array[i];
			}

			return SolveEquation(rem_one, rem_square);
		}

		public static int SquareSumToN(int n, int power)
		{
			int sum = 0;
			for (int i = 1; i <= n; i++)
			{
				sum += (int)Math.Pow(i, power);
			}
			return sum;
		}

		public static int[] SolveEquation(int r1, int r2)
		{
			/* ax^2 + bx + c 
			 * -->
			 * x = [-b +- sqrt(b^2 - 4ac)] / 2a
			 * In this case, it has to be a + not a -
			 * 
			 */
			int a = 2;
			int b = -2 * r1;
			int c = r1 * r1 - r2;

			double part1 = -1 * b;
			double part2 = Math.Sqrt(b * b - 4 * a * c);
			double part3 = 2 * a;


			int solutionX = (int)((part1 + part2) / part3);
			int solutionY = r1 - solutionX;

			int solutionX2 = (int)((part1 - part2) / part3);
			int solutionY2 = r1 - solutionX2;

			Console.WriteLine("Alternate: (" + solutionX2 + ", " + solutionY2 + ")");

			int[] solution = { solutionX, solutionY };
			return solution;
		}

		public override void Run()
        {
			int max = 100;
			for (int x = 1; x < max; x++)
			{
				for (int y = 1; y < max; y++)
				{
					if (x != y)
					{
						int len = max - 2;
						int count = 0;
						int[] array = new int[len];
						for (int i = 1; i <= max; i++)
						{
							if (i != x && i != y)
							{
								array[count] = i;
								count++;
							}
						}
						int[] solution = MissingTwoC(array);

						if ((solution[0] == x && solution[1] == y) ||
							(solution[1] == x && solution[0] == y))
						{
							Console.WriteLine("Success: " + solution[0] + ", " + solution[1]);
						}
						else
						{
							Console.WriteLine("Error: " + x + ", " + y + " | " + solution[0] + ", " + solution[1]);
						}
					}
				}
			}
		}
    }
}
