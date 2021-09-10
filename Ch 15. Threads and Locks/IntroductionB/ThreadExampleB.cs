using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.IntroductionB
{
    public class ThreadExampleB
    {
		public int Count { get; private set; } = 0;

		private Thread _thread;

		public ThreadExampleB()
		{
			_thread = new Thread(Run);
		}

		// Thread methods / properties
		public void Start() => _thread.Start();
		public void Join() => _thread.Join();
		public bool IsAlive => _thread.IsAlive;


		public void Run()
		{
			Console.WriteLine("Thread starting.");
			try
			{
				while (Count < 5)
				{
					Thread.Sleep(500);
					Console.WriteLine("In Thread, count is " + Count);
					Count++;
				}
			}
			catch (ThreadInterruptedException exc)
			{
				Console.WriteLine("Thread interrupted.");
			}
			Console.WriteLine("Thread terminating.");
		}
    }
}
