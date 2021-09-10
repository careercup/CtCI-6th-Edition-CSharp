using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_07_FizzBuzz
{
    public class FizzBuzzThread
    {
		private static Object myLock = new Object();
		protected static int current = 1;
		private int max;
		private bool div3, div5;
		private string toPrint;
		private Thread _thread;

		public FizzBuzzThread(bool div3, bool div5, int max, string toPrint)
		{
			this.div3 = div3;
			this.div5 = div5;
			this.max = max;
			this.toPrint = toPrint;
			_thread = new Thread(Run);
		}

		// Thread methods / properties
		public void Start() => _thread.Start();
		public void Join() => _thread.Join();
		public bool IsAlive => _thread.IsAlive;
		public virtual void Print()
		{
			Console.WriteLine(toPrint);
		}

		public void Run()
		{
			while (true)
			{
				lock(myLock)
				{
					if (current > max)
					{
						return;
					}

					if ((current % 3 == 0) == div3 && (current % 5 == 0) == div5)
					{
						Print();
						current++;
					}
				}
			}
		}
	}
}
