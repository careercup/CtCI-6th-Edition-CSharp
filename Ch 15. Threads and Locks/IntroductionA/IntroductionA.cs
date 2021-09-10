using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.IntroductionA
{
    public class IntroductionA : Question
    {
        public override void Run()
        {
			RunnableThreadExampleA thread = new RunnableThreadExampleA();
			thread.Start();

			/* waits until earlier thread counts to 5 (slowly) */
			while (thread.Count != 5)
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

			Console.WriteLine("Program Terminating.");
		}
    }
}
