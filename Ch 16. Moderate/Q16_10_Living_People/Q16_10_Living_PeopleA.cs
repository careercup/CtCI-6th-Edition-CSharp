using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_10_Living_People
{
	// 暴力解
	// Time complexity: O(RP)
	// R: 年範圍(此例為101)
	// P: 人數
	public class Q16_10_Living_PeopleA : Question
    {
		public static int MaxAliveYear(Person[] people, int min, int max)
		{
			int maxAlive = 0;
			int maxAliveYear = min;

			for (int year = min; year <= max; year++)
			{
				int alive = 0;
				foreach (Person person in people)
				{
					if (person.birth <= year && year <= person.death)
					{
						alive++;
					}
				}
				if (alive > maxAlive)
				{
					maxAlive = alive;
					maxAliveYear = year;
				}
			}

			return maxAliveYear;
		}

		public override void Run()
        {
			int n = 10000;
			int first = 1900;
			int last = 2000;
			Random random = new Random();
			Person[] people = new Person[n];
			for (int i = 0; i < n; i++)
			{
				int birth = first + random.Next(last - first);
				int death = birth + random.Next(last - birth);
				people[i] = new Person(birth, death);
				//Console.WriteLine(birth + ", " + death);
			}

			Console.WriteLine(n);
			for (int i = 0; i < n; i++)
			{
				//int birth = first + random.nextInt(last - first);
				//int death = birth + random.nextInt(last - birth);
				//people[i] = new Person(birth, death);
				Console.WriteLine(people[i].birth);
			}
			Console.WriteLine(n);
			for (int i = 0; i < n; i++)
			{
				//int birth = first + random.nextInt(last - first);
				//int death = birth + random.nextInt(last - birth);
				//people[i] = new Person(birth, death);
				Console.WriteLine(people[i].death);
			}

			int year = MaxAliveYear(people, first, last);

			Console.WriteLine($"MaxAliveYear = {year}");
		}
    }
}
