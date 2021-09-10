using ctci.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ch_15._Threads_and_Locks.Q15_03_Dining_Philosophers.QuestionB
{
    public class Philosopher
    {
		private readonly int maxPause = 100;
		private int bites = 10;

		private Chopstick lower;
		private Chopstick higher;
		private int index;
		private Thread _thread;


		public Philosopher(int i, Chopstick left, Chopstick right)
		{
			index = i;
			if (left.GetNumber() < right.GetNumber())
			{
				this.lower = left;
				this.higher = right;
			}
			else
			{
				this.lower = right;
				this.higher = left;
			}
			_thread = new Thread(Run);
		}

		// Thread methods / properties
		public void Start() => _thread.Start();
		public void Join() => _thread.Join();
		public bool IsAlive => _thread.IsAlive;

		public void Eat()
		{
			Console.WriteLine("Philosopher " + index + ": start eating");
			PickUp();
			Chew();
			PutDown();
			Console.WriteLine("Philosopher " + index + ": done eating");
		}

		public void PickUp()
		{
			Pause();
			lower.PickUp();
			Pause();
			higher.PickUp();
			Pause();
		}

		public void Chew()
		{
			Console.WriteLine("Philosopher " + index + ": eating");
			Pause();
		}

		public void Pause()
		{
			try
			{
				int pause = AssortedMethods.RandomIntInRange(0, maxPause);
				Thread.Sleep(pause);
			}
			catch (ThreadInterruptedException e)
			{
				Console.WriteLine(e.StackTrace);
			}
		}

		public void PutDown()
		{
			higher.PutDown();
			lower.PutDown();
		}

		public void Run()
		{
			for (int i = 0; i < bites; i++)
			{
				Eat();
			}
		}
	}
}
