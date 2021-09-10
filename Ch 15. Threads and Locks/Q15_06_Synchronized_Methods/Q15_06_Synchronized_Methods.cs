using ctci.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_06_Synchronized_Methods
{
	// 每個物件實例同時間只能執行一個同步化方法。
	// 其他執行緒可以執行該實例的非同步化方法或物件不同實例的任何方法。
    public class Q15_06_Synchronized_Methods : Question
    {
        public override void Run()
        {
			/* Part 1 Demo -- same instance */
			Console.WriteLine("Part 1 Demo with same instance.");
			Foo fooA = new Foo("ObjectOne");
			MyThread thread1a = new MyThread(fooA, "Dog", "A");
			MyThread thread2a = new MyThread(fooA, "Cat", "A");
			thread1a.Start();
			thread2a.Start();
			while (thread1a.IsAlive || thread2a.IsAlive) { };
			Console.WriteLine("\n\n");

			/* Part 1 Demo -- difference instances */
			Console.WriteLine("Part 1 Demo with different instances.");
			Foo fooB1 = new Foo("ObjectOne");
			Foo fooB2 = new Foo("ObjectTwo");
			MyThread thread1b = new MyThread(fooB1, "Dog", "A");
			MyThread thread2b = new MyThread(fooB2, "Cat", "A");
			thread1b.Start();
			thread2b.Start();
			while (thread1b.IsAlive || thread2b.IsAlive) { };
			Console.WriteLine("\n\n");

			/* Part 2 Demo */
			Console.WriteLine("Part 2 Demo.");
			Foo fooC = new Foo("ObjectOne");
			MyThread thread1c = new MyThread(fooC, "Dog", "A");
			MyThread thread2c = new MyThread(fooC, "Cat", "B");
			thread1c.Start();
			thread2c.Start();
		}
    }
}
