using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_03._Stacks_and_Queues.Q3_06_Animal_Shelter
{
	public abstract class Animal
	{
		private int order;
		protected string name;
		public Animal(string n)
		{
			name = n;
		}

		public abstract string GetName();

		public void SetOrder(int ord)
		{
			order = ord;
		}

		public int getOrder()
		{
			return order;
		}

		public bool IsOlderThan(Animal a)
		{
			return this.order < a.getOrder();
		}
	}
}
