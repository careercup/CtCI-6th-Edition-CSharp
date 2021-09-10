using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.IntroductionLocksF
{
    public class MyClass
    {
		private NoLockATM noLockATM;
		private LockedATM lockedATM;
		public int Delta { get; private set; } = 0;

		private static object myLock = new object();

		private Thread _thread;

		public MyClass(NoLockATM atm1, LockedATM atm2)
		{
			noLockATM = atm1;
			lockedATM = atm2;
			_thread = new Thread(Run);
		}

		// Thread methods / properties
		public void Start() => _thread.Start();
		public void Join() => _thread.Join();
		public bool IsAlive => _thread.IsAlive;


		public void Run()
		{
			lock (myLock)
			{
				int[] operations = AssortedMethods.RandomArray(20, -50, 50);
				foreach (int op in operations)
				{
					Delta += op;
					if (op < 0)
					{
						int val = op * -1;
						noLockATM.withdraw(val);
						lockedATM.withdraw(val);
					}
					else
					{
						noLockATM.deposit(op);
						lockedATM.deposit(op);
					}
				}
			}
		}
	}
}
