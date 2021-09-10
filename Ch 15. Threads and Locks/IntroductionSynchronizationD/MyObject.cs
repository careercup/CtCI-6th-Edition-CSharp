using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.IntroductionSynchronizationD
{
	public class MyObject
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void Foo(string name)
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

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static void Bar(string name)
		{
			try
			{
				Console.WriteLine("Thread " + name + ".bar(): starting");
				Thread.Sleep(3000);
				Console.WriteLine("Thread " + name + ".bar(): ending");
			}
			catch (ThreadInterruptedException exc)
			{
				Console.WriteLine("Thread " + name + ": interrupted.");
			}
		}
	}
}
