﻿using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.IntroductionSynchronizationD
{
    public class IntroductionSynchronizationD : Question
    {

        public override void Run()
        {
            try
            {
                MyObject obj1 = new MyObject();
                MyObject obj2 = new MyObject();
                MyClass thread1 = new MyClass(obj1, "1");
                MyClass thread2 = new MyClass(obj2, "2");

                thread1.Start();
                thread2.Start();

                Thread.Sleep(3000 * 3);
            }
            catch (ThreadInterruptedException exc)
            {
                Console.WriteLine("Program Interrupted.");
            }
            Console.WriteLine("Program terminating.");
        }
    }
}