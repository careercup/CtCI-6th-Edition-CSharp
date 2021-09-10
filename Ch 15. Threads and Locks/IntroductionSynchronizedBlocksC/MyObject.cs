using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.IntroductionSynchronizedBlocksC
{
    public class MyObject
    {
        static object Lock = new object();

        public void Foo(string name)
        {
            lock (Lock)
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
}
