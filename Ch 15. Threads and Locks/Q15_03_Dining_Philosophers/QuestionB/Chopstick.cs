using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_03_Dining_Philosophers.QuestionB
{
    public class Chopstick
    {
		private int number;
		public Chopstick(int n)
		{
			this.number = n;
		}

		public void PickUp()
		{
			Monitor.Enter(this);
		}

		public void PutDown()
		{
			Monitor.Exit(this);
		}

		public int GetNumber()
		{
			return number;
		}
	}
}
