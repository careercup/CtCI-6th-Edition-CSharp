using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_05_Call_In_Order
{
	
    public class Q15_05_Call_In_Order : Question
    {
        public override void Run()
        {
			FooBad foo = new Foo();

			MyThread thread1 = new MyThread(foo, "first");
			MyThread thread2 = new MyThread(foo, "second");
			MyThread thread3 = new MyThread(foo, "third");

			thread3.Start();
			thread2.Start();
			thread1.Start();

			//// FooBad 動作有問題
			//foo = new FooBad();

			//thread1 = new MyThread(foo, "first");
			//thread2 = new MyThread(foo, "second");
			//thread3 = new MyThread(foo, "third");

			//thread3.Start();
			//thread2.Start();
			//thread1.Start();
		}
    }
}
