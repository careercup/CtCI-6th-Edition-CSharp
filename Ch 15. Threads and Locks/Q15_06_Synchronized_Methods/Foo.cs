using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_06_Synchronized_Methods
{
	public class Foo
	{
		private string name;

		public Foo(string nm)
		{
			name = nm;
		}

		public string GetName()
		{
			return name;
		}

		public void Pause()
		{
			try
			{
				Thread.Sleep(1000 * 3);
			}
			catch (ThreadInterruptedException e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void MethodA(string threadName)
		{
			Console.WriteLine("thread " + threadName + " starting: " + name + ".methodA()");
			Pause();
			Console.WriteLine("thread " + threadName + " ending: " + name + ".methodA()");
		}

		public void MethodB(string threadName)
		{
			Console.WriteLine("thread " + threadName + " starting: " + name + ".methodB()");
			Pause();
			Console.WriteLine("thread " + threadName + " ending: " + name + ".methodB()");
		}
	}
}
