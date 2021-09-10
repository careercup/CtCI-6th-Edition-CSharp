using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.IntroductionWaitNotifyE
{
	public class MyObject
	{
		public void Foo(string name)
		{
			try
			{
				Console.WriteLine("Thread " + name + ".foo(): starting");
				Thread.Sleep(3000);
				Console.WriteLine("Thread " + name + ".foo(): ending");
			}
			catch (ThreadInterruptedException exc)
			{
				Console.WriteLine("Thread " + name + ": interrupted.");
			}
		}
	}
}
