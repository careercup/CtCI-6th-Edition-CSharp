using ctci.Contracts;
using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.IntroductionLocksF
{
	// 此方法轉換應該有錯，測出來結果感覺怪怪的
    public class IntroductionLocksF : Question
    {

		public override void Run()
        {
			NoLockATM noLockATM = new NoLockATM();
			LockedATM lockedATM = new LockedATM();


			MyClass thread1 = new MyClass(noLockATM, lockedATM);
			MyClass thread2 = new MyClass(noLockATM, lockedATM);

			thread1.Start();
			thread2.Start();

			try
			{
				Thread.Sleep(1000);
			}
			catch (ThreadInterruptedException e)
			{
				// TODO Auto-generated catch block
				Console.WriteLine(e.StackTrace);
			}

			Console.WriteLine("NoLock ATM: " + noLockATM.getBalance());
			Console.WriteLine("Locked ATM: " + lockedATM.getBalance());
			int v = thread1.Delta + thread2.Delta + 100;
			Console.WriteLine("Should Be: " + v);
			Console.WriteLine("Program terminating.");
		}
    }
}
