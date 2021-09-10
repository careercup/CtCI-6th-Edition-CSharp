using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.IntroductionA
{
	// C# 沒有 Runnable 所以改由 Thread + ThreadStart 取代
	public class RunnableThreadExampleA
    {
		public int Count { get; private set; } = 0;

		private Thread _thread;

		public RunnableThreadExampleA()
		{
			_thread = new Thread(new ThreadStart(Run));
		}

		// Thread methods / properties
		public void Start() => _thread.Start();
		public void Join() => _thread.Join();
		public bool IsAlive => _thread.IsAlive;

		public void Run()
		{
			Console.WriteLine("RunnableThread starting.");
			try
			{
				while (Count < 5)
				{
					Thread.Sleep(500);
					Console.WriteLine("RunnableThread count: " + Count);
					Count++;
				}
			}
			catch (ThreadInterruptedException exc)
			{
				Console.WriteLine("RunnableThread interrupted.");
			}
			Console.WriteLine("RunnableThread terminating.");
		}

    }
}
