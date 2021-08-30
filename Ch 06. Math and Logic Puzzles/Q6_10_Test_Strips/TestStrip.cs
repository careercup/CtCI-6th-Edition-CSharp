using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_06._Math_and_Logic_Puzzles.Q6_10_Test_Strips
{
	public class TestStrip
	{
		public static int DAYS_FOR_RESULT = 7;
		private IList<IList<Bottle>> dropsByDay = new List<IList<Bottle>>();
		private int id;

		public TestStrip(int id)
		{
			this.id = id;
		}

		public int GetId()
		{
			return id;
		}

		/* Resize list of days/drops to be large enough. */
		private void SizeDropsForDay(int day)
		{
			while (dropsByDay.Count <= day)
			{
				dropsByDay.Add(new List<Bottle>());
			}
		}

		/* Add drop from bottle on specific day. */
		public void AddDropOnDay(int day, Bottle bottle)
		{
			SizeDropsForDay(day);
			IList<Bottle> drops = dropsByDay[day];
			drops.Add(bottle);
		}

		/* Checks if any of the bottles in the set are poisoned. */
		private bool HasPoison(IList<Bottle> bottles)
		{
			foreach (Bottle b in bottles)
			{
				if (b.IsPoisoned())
				{
					return true;
				}
			}
			return false;
		}

		/* Gets bottles that were used in the test DAYS_FOR_RESULT days ago. */
		public IList<Bottle> GetLastWeeksBottles(int day)
		{
			if (day < DAYS_FOR_RESULT)
			{
				return null;
			}
			return dropsByDay[day - DAYS_FOR_RESULT];
		}

		/* Checks if the test strip has had any poisoned bottles since before DAYS_FOR_RESULT */
		public bool IsPositiveOnDay(int day)
		{
			int testDay = day - DAYS_FOR_RESULT;
			if (testDay < 0 || testDay >= dropsByDay.Count)
			{
				return false;
			}
			for (int d = 0; d <= testDay; d++)
			{
				IList<Bottle> bottles = dropsByDay[d];
				if (HasPoison(bottles))
				{
					return true;
				}
			}
			return false;
		}
	}
}
