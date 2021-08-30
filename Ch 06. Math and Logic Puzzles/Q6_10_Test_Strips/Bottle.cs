using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_06._Math_and_Logic_Puzzles.Q6_10_Test_Strips
{
	public class Bottle
	{
		private bool poisoned = false;
		private int id;

		public Bottle(int id)
		{
			this.id = id;
		}

		public int GetId()
		{
			return id;
		}

		public void SetAsPoisoned()
		{
			poisoned = true;
		}

		public bool IsPoisoned()
		{
			return poisoned;
		}
	}
}
