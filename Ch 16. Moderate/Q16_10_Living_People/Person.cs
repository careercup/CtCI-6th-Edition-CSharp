using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_16._Moderate.Q16_10_Living_People
{
	public class Person
	{
		public int birth { get; private set; }
		public int death { get; private set; }
		public Person(int birthYear, int deathYear)
		{
			birth = birthYear;
			death = deathYear;
		}
	}
}
