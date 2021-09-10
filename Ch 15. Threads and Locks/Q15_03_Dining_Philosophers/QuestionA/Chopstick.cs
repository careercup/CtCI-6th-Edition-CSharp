using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_03_Dining_Philosophers.QuestionA
{
    public class Chopstick
    {
		public bool PickUp()
		{
			return Monitor.TryEnter(this);
		}

		public void PutDown()
		{
			Monitor.Exit(this);
		}
	}
}
