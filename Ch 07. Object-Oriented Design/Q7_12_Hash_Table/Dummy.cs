using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_07._Object_Oriented_Design.Q7_12_Hash_Table
{
	public class Dummy
	{
		private string name;
		private int age;
		public Dummy(string n, int a)
		{
			name = n;
			age = a;
		}

		public override string ToString()
		{
			return "(" + name + ", " + age + ")";
		}

		public int GetAge()
		{
			return age;
		}

		public string GetName()
		{
			return name;
		}
	}

}
