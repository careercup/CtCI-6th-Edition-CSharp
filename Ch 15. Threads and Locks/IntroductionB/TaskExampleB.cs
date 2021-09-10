using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.IntroductionB
{
    public class TaskExampleB : Question
    {
		public int Count { get; private set; } = 0;

		public void RunFunc()
		{
			Console.WriteLine("Task starting.");
			try
			{
				while (Count < 5)
				{
					Thread.Sleep(500);
					Console.WriteLine("In Task, count is " + Count);
					Count++;
				}
			}
			catch (ThreadInterruptedException exc)
			{
				Console.WriteLine("Task interrupted.");
			}
			Console.WriteLine("Task terminating.");
		}

		public override void Run()
        {
			Task.Run(() => RunFunc());

			while (Count != 5)
			{
				try
				{
					Thread.Sleep(250);
				}
				catch (ThreadInterruptedException exc)
				{
					Console.WriteLine(exc.StackTrace);
				}
			}
		}
    }
}
