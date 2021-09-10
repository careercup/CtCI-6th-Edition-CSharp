using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.IntroductionLocksF
{
	public class NoLockATM
	{
		private int balance = 100;

		public NoLockATM()
		{
		}

		public int withdraw(int value)
		{
			int temp = balance;
			try
			{
				Thread.Sleep(300);
				temp = temp - value;
				Thread.Sleep(300);
				balance = temp;
			}
			catch (ThreadInterruptedException e) { }
			return temp;
		}

		public int deposit(int value)
		{
			int temp = balance;
			try
			{
				Thread.Sleep(300);
				temp = temp + value;
				Thread.Sleep(300);
				balance = temp;
			}
			catch (ThreadInterruptedException e) { }
			return temp;
		}

		public int getBalance()
		{
			return balance;
		}
	}
}
