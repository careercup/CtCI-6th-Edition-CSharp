using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_10_Living_People
{
	// 更好的方案(或許)
	// Time complexity: O(R + P)
	// R: 年範圍(此例為102)，死亡數需要隔一年才能移除，所以陣列多加1個空間
	// P: 人數
	public class Q16_10_Living_PeopleD : Question
    {
		public static int MaxAliveYear(Person[] people, int min, int max)
		{
			/* Build population delta array. */
			int[] populationDeltas = GetPopulationDeltas(people, min, max);
			int maxAliveYear = GetMaxAliveYear(populationDeltas);
			return maxAliveYear + min;
		}

		/* Add birth and death years to deltas array. */
		public static int[] GetPopulationDeltas(Person[] people, int min, int max)
		{
			int[] populationDeltas = new int[max - min + 2];
			foreach (Person person in people)
			{
				int birth = person.birth - min;
				populationDeltas[birth]++;

				int death = person.death - min;
				populationDeltas[death + 1]--;
			}
			return populationDeltas;
		}

		/* Compute running sums and return index with max. */
		public static int GetMaxAliveYear(int[] deltas)
		{
			int maxAliveYear = 0;
			int maxAlive = 0;
			int currentlyAlive = 0;
			for (int year = 0; year < deltas.Length; year++)
			{
				currentlyAlive += deltas[year];
				if (currentlyAlive > maxAlive)
				{
					maxAliveYear = year;
					maxAlive = currentlyAlive;
				}
			}

			return maxAliveYear;
		}

		public override void Run()
        {
			int n = 3;
			int first = 1900;
			int last = 2000;
			Random random = new Random();
			Person[] people = new Person[n];
			for (int i = 0; i < n; i++)
			{
				int birth = first + random.Next(last - first);
				int death = birth + random.Next(last - birth);
				people[i] = new Person(birth, death);
				Console.WriteLine(birth + ", " + death);
			}
			int year = MaxAliveYear(people, first, last);
			Console.WriteLine($"MaxAliveYear = {year}");
		}
    }
}
