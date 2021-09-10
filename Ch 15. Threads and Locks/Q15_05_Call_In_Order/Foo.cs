using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_05_Call_In_Order
{
    public class Foo : FooBad
	{
		public int pauseTime = 1000;
		public Semaphore sem1;
		public Semaphore sem2;

		public Foo()
		{
			try
			{
				sem1 = new Semaphore(1,1);
				sem2 = new Semaphore(1,1);

				sem1.WaitOne();
				sem2.WaitOne();
			}
			catch (ThreadInterruptedException e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		public override void First()
		{
			try
			{
				Console.WriteLine("Foo Started Executing 1");
				Thread.Sleep(pauseTime);
				Console.WriteLine("Foo Finished Executing 1");
				sem1.Release();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		public override void Second()
		{
			try
			{
				sem1.WaitOne();
				sem1.Release();
				Console.WriteLine("Foo Started Executing 2");
				Thread.Sleep(pauseTime);
				Console.WriteLine("Foo Finished Executing 2");
				sem2.Release();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}

		public override void Third()
		{
			try
			{
				sem2.WaitOne();
				sem2.Release();
				Console.WriteLine("Foo Started Executing 3");
				Thread.Sleep(pauseTime);
				Console.WriteLine("Foo Finished Executing 3");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}
	}
}
