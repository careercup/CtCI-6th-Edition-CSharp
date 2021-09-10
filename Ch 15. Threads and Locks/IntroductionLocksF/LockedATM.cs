using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.IntroductionLocksF
{
    public class LockedATM
    {
        private static object mylock = new object();
        private int balance = 100;

        public LockedATM()
        {
        }

        public int withdraw(int value)
        {
            Monitor.Enter(this);
            int temp = balance;
            try
            {
                Thread.Sleep(100);
                temp = temp - value;
                Thread.Sleep(100);
                balance = temp;
            }
            catch (ThreadInterruptedException e) { }
            Monitor.Exit(this);
            return temp;
        }

        public int deposit(int value)
        {
            Monitor.Enter(this);
            int temp = balance;

            try
            {
                Thread.Sleep(100);
                temp = temp + value;
                Thread.Sleep(100);
                balance = temp;
            }
            catch (ThreadInterruptedException e) { }
            Monitor.Exit(this);
            return temp;
        }

        public int getBalance()
        {
            return balance;
        }
    }
}
