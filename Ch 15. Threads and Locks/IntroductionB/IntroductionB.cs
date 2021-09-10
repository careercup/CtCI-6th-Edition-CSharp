using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.IntroductionB
{
    public class IntroductionB : Question
    {
        public override void Run()
        {

            ThreadExampleB instance = new ThreadExampleB();
            instance.Start();

            while (instance.Count != 5)
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
