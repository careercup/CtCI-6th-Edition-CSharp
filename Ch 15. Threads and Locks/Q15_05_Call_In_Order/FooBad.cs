using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_05_Call_In_Order
{
	public class FooBad
	{
		public int PauseTime { get; set; } = 1000;
		private static object lock1;
		private static object lock2;

		public FooBad()
		{
			try
			{
				lock1 = new object();
				lock2 = new object();

				Monitor.Enter(lock1);
				Monitor.Enter(lock2);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		public virtual void First()
		{
			try
			{
				Console.WriteLine("FooBad Started Executing 1");
				Thread.Sleep(PauseTime);
				Console.WriteLine("FooBad Finished Executing 1");
				Monitor.Exit(lock1);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		public virtual void Second()
		{
			try
			{
				Monitor.Enter(lock1);
				Monitor.Exit(lock1);
				Console.WriteLine("FooBad Started Executing 2");
				Thread.Sleep(PauseTime);
				Console.WriteLine("FooBad Finished Executing 2");
				Monitor.Exit(lock2);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		public virtual void Third()
		{
			try
			{
				Monitor.Enter(lock2);
				Monitor.Exit(lock2);
				Console.WriteLine("FooBad Started Executing 3");
				Thread.Sleep(PauseTime);
				Console.WriteLine("FooBad Finished Executing 3");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}
	}
}
