using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_10_Living_People
{
	// 比暴力解好一點的方案
	// Time complexity: O(RY + R)
	// R: 年範圍(此例為101)
	// P: 人數
	// Y: 該人活著的年
	public class Q16_10_Living_PeopleB : Question
    {
		public static int MaxAliveYear(Person[] people, int min, int max)
		{
			int[] years = CreateYearMap(people, min, max);
			int best = GetMaxIndex(years);

			return best + min;
		}

		/* Add each person's years to a year map. */
		public static int[] CreateYearMap(Person[] people, int min, int max)
		{
			int[] years = new int[max - min + 1];
			foreach (Person person in people)
			{
				int left = person.birth - min;
				int right = person.death - min;
				IncrementRange(years, left, right);
			}
			return years;
		}

		/* Increment array for each value between left and right. */
		public static void IncrementRange(int[] values, int left, int right)
		{
			for (int i = left; i <= right; i++)
			{
				values[i]++;
			}
		}

		/* Get index of largest element in array. */
		public static int GetMaxIndex(int[] values)
		{
			int max = 0;
			for (int i = 1; i < values.Length; i++)
			{
				if (values[i] > values[max])
				{
					max = i;
				}
			}
			return max;
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
