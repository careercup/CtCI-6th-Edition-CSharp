using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_08._Recursion_and_Dynamic_Programming.Q8_10_Paint_Fill
{
    public class Q8_10_Paint_Fill : Question
    {
		public static bool PaintFill(Color[][] screen, int r, int c, Color ncolor)
		{
			if (screen[r][c] == ncolor) return false;
			return PaintFill(screen, r, c, screen[r][c], ncolor);
		}

		public static bool PaintFill(Color[][] screen, int r, int c, Color ocolor, Color ncolor)
		{
			if (r < 0 || r >= screen.Length || c < 0 || c >= screen[0].Length)
			{
				return false;
			}
			if (screen[r][c] == ocolor)
			{
				screen[r][c] = ncolor;
				PaintFill(screen, r - 1, c, ocolor, ncolor); // up
				PaintFill(screen, r + 1, c, ocolor, ncolor); // down
				PaintFill(screen, r, c - 1, ocolor, ncolor); // left
				PaintFill(screen, r, c + 1, ocolor, ncolor); // right
			}
			return true;
		}

		public static void PrintScreen(Color[][] screen)
		{
			for (int r = 0; r < screen.Length; r++)
			{
				for (int c = 0; c < screen[0].Length; c++)
				{
					Console.Write(PrintColor(screen[r][c]));
				}
				Console.WriteLine();
			}
		}

			

		public static string PrintColor(Color c)
		{
			switch (c)
			{
				case Color.Black:
					return "B";
				case Color.White:
					return "W";
				case Color.Red:
					return "R";
				case Color.Yellow:
					return "Y";
				case Color.Green:
					return "G";
			}
			return "X";
		}

		public static int randomInt(int n)
		{
			return new Random().Next(n);
		}

		public override void Run()
        {
			int N = 10;
			Color[][] screen = new Color[N][];
			for (int i = 0; i < N; i++)
			{
				screen[i] = new Color[N];
				for (int j = 0; j < N; j++)
				{
					screen[i][j] = Color.Black;
				}
			}
			for (int i = 0; i < 100; i++)
			{
				screen[randomInt(N)][randomInt(N)] = Color.Green;
			}
			PrintScreen(screen);
			PaintFill(screen, 2, 2, Color.White);
			Console.WriteLine();
			PrintScreen(screen);
		}
    }
}
