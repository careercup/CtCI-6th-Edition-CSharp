using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_06._Math_and_Logic_Puzzles.Q6_07_The_Apocalypse
{
	// n夠大會接近0.5，政策無法改變性別比例
    public class Q6_07_The_Apocalypse : Question
    {
		public static double RunNFamilies(int n)
		{
			int boys = 0;
			int girls = 0;
			for (int i = 0; i < n; i++)
			{
				int[] genders = RunOneFamily();
				girls += genders[0];
				boys += genders[1];
			}
			return girls / (double)(boys + girls);
		}


		public static int[] RunOneFamily()
		{
			Random random = new Random();
			int boys = 0;
			int girls = 0;
			while (girls == 0)
			{ // until we have a girl
				if (random.Next(2) == 1) 
				{ // girl
					girls += 1;
				}
				else
				{ // boy
					boys += 1;
				}
			}
			int[] genders = { girls, boys };
			return genders;
		}
		
		public override void Run()
        {
			double ratio = RunNFamilies(10000000);
			Console.WriteLine(ratio);
		}
    }
}
